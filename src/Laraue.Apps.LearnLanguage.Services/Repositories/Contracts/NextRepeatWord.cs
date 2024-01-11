using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record NextRepeatWordTranslation(
    long Id,
    string Name,
    string Translation,
    DateTime? LearnedAt,
    DateTime? RepeatedAt,
    int LearnAttempts,
    string? CefrLevel,
    string? Topic,
    WordTranslationDifficulty? Difficulty);
    
