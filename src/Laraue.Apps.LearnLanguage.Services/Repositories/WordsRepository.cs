using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class WordsRepository(DatabaseContext context) : IWordsRepository
{
    public Task ChangeWordLearnStateAsync(
        Guid userId,
        long wordTranslationId,
        LearnState flagToChange,
        CancellationToken ct = default)
    {
        return context.WordTranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new WordTranslationState
                {
                    WordTranslationId = wordTranslationId,
                    UserId = userId,
                    LearnState = LearnState.None ^ flagToChange,
                    LearnedAt = flagToChange == LearnState.Learned
                        ? DateTime.UtcNow
                        : null,
                    LearnAttempts = 1,
                }, x => new WordTranslationState
                {
                    LearnState = x.LearnState ^ flagToChange,
                    LearnedAt = flagToChange == LearnState.Learned
                        ? (x.LearnState & LearnState.Learned) == 0
                            ? DateTime.UtcNow
                            : null
                        : x.LearnedAt,
                },
                () => new WordTranslationState
                {
                    UserId = userId,
                    WordTranslationId = wordTranslationId,
                },
                ct);
    }

    public async Task IncrementLearnAttemptsAsync(Guid userId, long[] wordTranslationIds, CancellationToken ct = default)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);
        
        var commonQuery = context.WordTranslationStates
            .Where(x =>
                wordTranslationIds.Contains(x.WordTranslationId)
                && userId == x.UserId);

        var existsStateIds = await commonQuery
            .Select(x => x.WordTranslationId)
            .ToListAsyncEF(ct);
        
        foreach (var wordTranslationId in wordTranslationIds.Except(existsStateIds))
        {
            context.WordTranslationStates.Add(new WordTranslationState
            {
                LearnAttempts = 1,
                WordTranslationId = wordTranslationId,
                UserId = userId,
            });
        }
        
        await commonQuery
            .Where(x => !x.LearnState.HasFlag(LearnState.Learned))
            .ExecuteUpdateAsync(u =>
                u.SetProperty(x => x.LearnAttempts, x => x.LearnAttempts + 1), ct);

        await context.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);
    }
}