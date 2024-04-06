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
                x.Key,
                LearnAttempts = x.Average(y => y.LearnAttempts)
            })
            .ToListAsyncEF();

        await context.Translations
            .ToLinqToDBTable()
            .Merge()
            .Using(attemptsStat
                .Select(x => new Translation
                {
                    Id = x.Key.TranslationId,
                    MeaningId = x.Key.MeaningId,
                    WordId = x.Key.WordId,
                    AverageAttempts = x.LearnAttempts,
                    Difficulty = GetDifficulty(x.LearnAttempts)
                }))
            .On(x => x.Id, x => x.Id)
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