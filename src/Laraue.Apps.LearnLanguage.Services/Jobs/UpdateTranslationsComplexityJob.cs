using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Jobs;

public class UpdateTranslationsComplexityJob(DatabaseContext context)
{
    public async Task ExecuteAsync()
    {
        var attemptsStat = await context.TranslationStates
            .Where(x => x.LearnedAt != null)
            .GroupBy(x => new { x.WordId, x.MeaningId, x.TranslationId })
            .Select(x => new
            {
                x.Key.WordId,
                x.Key.MeaningId,
                x.Key.TranslationId,
                LearnAttempts = x.Average(y => y.LearnAttempts)
            })
            .ToListAsyncEF();

        await context.Translations
            .ToLinqToDBTable()
            .Merge()
            .Using(attemptsStat
                .Select(x => new Translation
                {
                    WordId = x.WordId,
                    MeaningId = x.MeaningId,
                    Id = x.TranslationId,
                    AverageAttempts = x.LearnAttempts,
                    Difficulty = GetDifficulty(x.LearnAttempts) // Difficulty the meaning should have, not translation
                }))
            .On(x => new { x.WordId, x.MeaningId, x.Id }, x => new { x.WordId, x.MeaningId, x.Id })
            .UpdateWhenMatched((o, n) => new Translation
            {
                AverageAttempts = n.AverageAttempts,
                Difficulty = n.Difficulty
            })
            .MergeAsync();
    }

    private static WordTranslationDifficulty GetDifficulty(double learnAttempts)
    {
        return learnAttempts switch
        {
            < 1.2 => WordTranslationDifficulty.Easy,
            < 2.6 => WordTranslationDifficulty.Medium,
            < 4.3 => WordTranslationDifficulty.Hard,
            < 6.2 => WordTranslationDifficulty.ExtraHard,
            _ => WordTranslationDifficulty.Impossible
        };
    }
}