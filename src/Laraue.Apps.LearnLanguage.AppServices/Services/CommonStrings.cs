using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Laraue.Apps.LearnLanguage.Contracts.Enums;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public static class CommonStrings
{
    public static string? GetDifficultyString(WordTranslationDifficulty? difficulty, string? cefrLevel)
    {
        if (difficulty is null && cefrLevel is null)
        {
            return null;
        }
        
        var nonEmptyStrings = new [] { cefrLevel, GetDifficultyString(difficulty) }
            .Where(s => s != null);
                    
        return string.Join(", ", nonEmptyStrings);
    }

    private static string? GetDifficultyString(WordTranslationDifficulty? difficulty)
    {
        return difficulty switch
        {
            null => null,
            WordTranslationDifficulty.Easy => Mode.Difficulty_Easy,
            WordTranslationDifficulty.Medium => Mode.Difficulty_Medium,
            WordTranslationDifficulty.Hard => Mode.Difficulty_Hard,
            WordTranslationDifficulty.ExtraHard => Mode.Difficulty_VeryHard,
            _ => Mode.Difficulty_Impossible,
        };
    }

    public const string Divider = "─────────────────";
}