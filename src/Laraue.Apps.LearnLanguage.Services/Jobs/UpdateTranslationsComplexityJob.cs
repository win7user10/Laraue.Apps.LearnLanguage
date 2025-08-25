using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Jobs;

public class UpdateTranslationsComplexityJob(DatabaseContext context)
{
    public async Task ExecuteAsync()
    {
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