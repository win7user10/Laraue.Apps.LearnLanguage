﻿using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.Services.Services;

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
            WordTranslationDifficulty.Easy => "easy",
            WordTranslationDifficulty.Medium => "medium",
            WordTranslationDifficulty.Hard => "hard",
            WordTranslationDifficulty.ExtraHard => "very hard",
            _ => "impossible",
        };
    }
}