using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.EFCore.Extensions;
using Laraue.Core.DataAccess.Extensions;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Word = Laraue.Apps.LearnLanguage.Services.Repositories.Contracts.Word;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class WordsRepository : IWordsRepository
{
    private readonly DatabaseContext _context;

    public WordsRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ClosestUnlearnedGroups> GetClosestUnlearnedGroupsAsync(long groupId, CancellationToken ct = default)
    {
        var group = await _context.WordGroups
            .FirstAsync(x => x.Id == groupId, ct);
        
        var notLearnedGroups = await _context.WordGroupWords
            .QueryGroupWordsWithStates(_context, (word, state) => new { word, state })
            .Where(x => x.word.WordGroup.UserId == group.UserId)
            .GroupBy(x => x.word.WordGroupId, (x, y) => new
            {
                NotAllLearned = y
                    .Any(y => y.state == null || (y.state.LearnState & LearnState.Learned) == 0),
                Key = x,
            })
            .Where(x => x.NotAllLearned)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToListAsync(ct);

        var previousNotLearned = notLearnedGroups.LastOrDefault(x => x < group.Id);
        var nextNotLearned = notLearnedGroups.FirstOrDefault(x => x > group.Id);

        return new ClosestUnlearnedGroups(previousNotLearned, nextNotLearned);
    }

    public Task<bool> AreGroupsCreatedAsync(Guid userId, CancellationToken ct = default)
    {
        return _context.WordGroups
            .Where(x => x.UserId == userId)
            .AnyAsync(ct);
    }

    public Task<long> GetGroupSerialNumberAsync(long wordGroupId, CancellationToken ct = default)
    {
        return _context.WordGroups.Where(x => x.Id == wordGroupId)
            .Select(x => x.SerialNumber)
            .FirstAsync(ct);
    }

    public async Task<IFullPaginatedResult<Group>> GetGroupsAsync(
        Guid userId,
        PaginatedRequest request,
        CancellationToken ct = default)
    {
        var res = await _context.WordGroups
            .Where(x => x.UserId == userId)
            .OrderBy(x => x.Id)
            .Select(x => new {
                x.SerialNumber,
                x.Id,
                FirstWord = x.WordGroupWords
                    .Select(y => y.WordTranslation.Word.Name)
                    .OrderBy(y => y)
                    .First(),
                x.WordGroupWords.Count})
            .FullPaginateEFAsync(request, ct);

        var groupIds = res.Data.Select(x => x.Id);
        var learnStat = (await _context.WordGroupWords
            .QueryGroupWordsWithStates(_context, (word, state) => new { word.WordGroupId, state })
            .Where(x => groupIds.Contains(x.WordGroupId))
            .GroupBy(x => x.WordGroupId)
            .Select(x => new {x.Key, Value = x.Count(y => y.state
                .LearnState
                .HasFlag(LearnState.Learned)) })
            .ToListAsync(ct))
            .ToDictionary(x => x.Key, x => x.Value);

        return res.MapTo(x => new Group(
            x.Id,
            x.SerialNumber,
            x.FirstWord,
            learnStat[x.Id],
            x.Count));
    }

    public Task<IFullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        long groupId,
        ShowWordsMode filter,
        PaginatedRequest request,
        CancellationToken ct = default)
    {
        var dbQuery = _context.WordGroupWords
            .Where(x => x.WordGroupId == groupId)
            .OrderBy(x => x.SerialNumber)
            .QueryGroupWordsWithStates(
                _context,
                (word, state) => new
                {
                    Item = new LearningItem(
                        word.WordTranslation.Word.Name,
                        word.WordTranslation.Translation,
                        word.SerialNumber,
                        state.LearnState,
                        state.ViewCount,
                        word.WordTranslation.Id
                    ),
                    State = state,
                });

        if (filter.HasFlag(ShowWordsMode.Hard))
        {
            dbQuery = dbQuery.Where(x => (x.State.LearnState & LearnState.Hard) != 0);
        }

        if (filter.HasFlag(ShowWordsMode.NotLearned))
        {
            dbQuery = dbQuery.Where(x => (x.State.LearnState & LearnState.Learned) == 0);
        }
        
        return dbQuery
            .Select(x => x.Item)
            .FullPaginateLinq2DbAsync(request, ct);
    }

    public Task<Word> GetWordAsync(Guid userId, long serialNumber, CancellationToken ct = default)
    {
        return _context.WordGroupWords
            .Where(x => x.SerialNumber == serialNumber
                        && x.WordGroup.UserId == userId)
            .QueryGroupWordsWithStates(_context, (word, state) => new Word(
                word.WordTranslation.Word.Name,
                word.WordTranslation.Translation,
                word.SerialNumber,
                state.LearnState,
                serialNumber))
            .FirstAsync(ct);
    }

    public Task ChangeWordLearnStateAsync(
        Guid userId,
        long wordTranslationId,
        LearnState flagToChange,
        CancellationToken ct = default)
    {
        return _context.WordTranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new WordTranslationState
                {
                    WordTranslationId = wordTranslationId,
                    UserId = userId,
                    LearnState = LearnState.None ^ flagToChange,
                    LearnedAt = flagToChange == LearnState.Learned
                        ? DateTimeOffset.UtcNow
                        : null,
                    ViewCount = 1,
                }, x => new WordTranslationState
                {
                    LearnState = x.LearnState ^ flagToChange,
                    LearnedAt = flagToChange == LearnState.Learned
                        ? (x.LearnState & LearnState.Learned) == 0
                            ? DateTimeOffset.UtcNow
                            : null
                        : x.LearnedAt
                },
                () => new WordTranslationState
                {
                    UserId = userId,
                    WordTranslationId = wordTranslationId,
                },
                ct);
    }

    public async Task GenerateGroupsAsync(Guid userId, bool shuffleWords, CancellationToken ct = default)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(ct);

        var idsToInsert = await _context.WordTranslations
            .Select(x => x.WordId)
            .ToArrayAsync(ct);
        
        if (shuffleWords)
        {
            idsToInsert = idsToInsert.OrderBy(_ => Guid.NewGuid()).ToArray();
        }

        var wordGroups = idsToInsert.Chunk(Constants.WordGroupSize)
            .Select((group, wi) => new WordGroup
            {
                UserId = userId,
                WordGroupWords = group
                    .Select((x, ti) => new WordGroupWord
                    {
                        WordTranslationId = x,
                        SerialNumber = wi * Constants.WordGroupSize + ti + 1,
                    })
                    .ToList(),
                SerialNumber = wi + 1
            });
        
        _context.WordGroups.AddRange(wordGroups);

        await _context.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);
    }
}