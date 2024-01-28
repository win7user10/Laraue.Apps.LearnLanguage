using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class WordsRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    : IWordsRepository
{
    private readonly TimeSpan _learnAttemptTime = new(1, 0, 0);
    
    public Task ChangeWordLearnStateAsync(
        Guid userId,
        long wordTranslationId,
        bool? isLearned,
        bool? isMarked,
        CancellationToken ct = default)
    {
        if (!isLearned.HasValue && !isMarked.HasValue)
        {
            return Task.CompletedTask;
        }
        
        return context.WordTranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new WordTranslationState
                {
                    WordTranslationId = wordTranslationId,
                    UserId = userId,
                    LearnedAt = isLearned.GetValueOrDefault()
                        ? dateTimeProvider.UtcNow
                        : null,
                    IsMarked = isMarked.GetValueOrDefault(),
                    LearnAttempts = 1,
                }, x => new WordTranslationState
                {
                    LearnedAt = isLearned.HasValue
                        ? isLearned.Value
                            ? x.LearnedAt ?? dateTimeProvider.UtcNow
                            : null
                        : x.LearnedAt,
                    IsMarked = isMarked ?? x.IsMarked
                },
                () => new WordTranslationState
                {
                    UserId = userId,
                    WordTranslationId = wordTranslationId,
                },
                ct);
    }

    public Task IncrementLearnAttemptsIfRequiredAsync(Guid userId, long[] wordTranslationIds, CancellationToken ct = default)
    {
        if (wordTranslationIds.Length == 0)
        {
            return Task.CompletedTask;
        }
        
        var now = dateTimeProvider.UtcNow;
        
        return context.WordTranslationStates
            .ToLinqToDBTable()
            .Merge()
            .Using(wordTranslationIds
                .Select(id => new
                {
                    UserId = userId,
                    WordTranslationId = id
                }))
            .On(
                x => new { x.UserId, x.WordTranslationId },
                x => new { x.UserId, x.WordTranslationId })
            .UpdateWhenMatched((o, n) => new WordTranslationState
            {
                LearnAttempts = o.LastOpenedAt - now >= _learnAttemptTime && o.LearnedAt == null
                    ? o.LearnAttempts + 1
                    : o.LearnAttempts,
                LastOpenedAt = o.LastOpenedAt - now >= _learnAttemptTime
                    ? now
                    : o.LastOpenedAt,
            })
            .InsertWhenNotMatched(e => new WordTranslationState
            {
                UserId = userId,
                LearnAttempts = 1,
                LastOpenedAt = dateTimeProvider.UtcNow,
                WordTranslationId = e.WordTranslationId,
            })
            .MergeAsync(ct);
    }
}