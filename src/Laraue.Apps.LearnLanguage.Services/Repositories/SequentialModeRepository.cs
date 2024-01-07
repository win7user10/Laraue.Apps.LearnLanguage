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

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class SequentialModeRepository(DatabaseContext context) : ISequentialModeRepository
{
    public async Task<ClosestUnlearnedGroups> GetClosestUnlearnedGroupsAsync(long groupId, CancellationToken ct = default)
    {
        var group = await context.WordGroups
            .FirstAsyncEF(x => x.Id == groupId, ct);
        
        var notLearnedGroups = await context.WordGroupWords
            .QueryGroupWordsWithStates(context, (word, state) => new { word, state })
            .Where(x => x.word.WordGroup.UserId == group.UserId)
            .GroupBy(x => x.word.WordGroupId, (x, y) => new
            {
                NotAllLearned = y
                    .Any(z => z.state == null || (z.state.LearnState & LearnState.Learned) == 0),
                Key = x,
            })
            .Where(x => x.NotAllLearned)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToListAsyncEF(ct);

        var previousNotLearned = notLearnedGroups.LastOrDefault(x => x < group.Id);
        var nextNotLearned = notLearnedGroups.FirstOrDefault(x => x > group.Id);

        return new ClosestUnlearnedGroups(previousNotLearned, nextNotLearned);
    }

    public Task<bool> AreGroupsCreatedAsync(Guid userId, CancellationToken ct = default)
    {
        return context.WordGroups
            .Where(x => x.UserId == userId)
            .AnyAsyncEF(ct);
    }

    public Task<long> GetGroupSerialNumberAsync(long wordGroupId, CancellationToken ct = default)
    {
        return context.WordGroups.Where(x => x.Id == wordGroupId)
            .Select(x => x.SerialNumber)
            .FirstAsyncEF(ct);
    }

    public async Task<IFullPaginatedResult<Group>> GetGroupsAsync(
        Guid userId,
        PaginatedRequest request,
        CancellationToken ct = default)
    {
        var res = await context.WordGroups
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
        var learnStat = await context.WordGroupWords
            .QueryGroupWordsWithStates(context, (word, state) => new { word.WordGroupId, state })
            .Where(x => groupIds.Contains(x.WordGroupId))
            .GroupBy(x => x.WordGroupId)
            .DisableGuard()
            .ToDictionaryAsyncLinqToDB(
                x => x.Key,
                x => x.Count(y => y.state?
                    .LearnState
                    .HasFlag(LearnState.Learned) ?? false),
                ct);

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
        var dbQuery = context.WordGroupWords
            .Where(x => x.WordGroupId == groupId)
            .OrderBy(x => x.SerialNumber)
            .QueryGroupWordsWithStates(
                context,
                (word, state) => new
                {
                    Item = new LearningItem(
                        word.WordTranslation.Word.Name,
                        word.WordTranslation.Translation,
                        word.SerialNumber,
                        state.LearnState,
                        word.WordTranslation.Difficulty,
                        word.WordTranslation.Id,
                        word.WordTranslation.Word.WordCefrLevel!.Name,
                        word.WordTranslation.Word.WordTopic!.Name,
                        state.LearnedAt,
                        state.RepeatedAt
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

    public async Task GenerateGroupsAsync(Guid userId, bool shuffleWords, CancellationToken ct = default)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);

        var idsToInsert = await context.WordTranslations
            .Select(x => x.WordId)
            .ToArrayAsyncEF(ct);
        
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
        
        context.WordGroups.AddRange(wordGroups);

        await context.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);
    }
}