using Laraue.Apps.LearnLanguage.Contracts;
using Laraue.Apps.LearnLanguage.Contracts.Enums;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public record NextRepeatWordTranslation(
    TranslationIdentifier Id,
    string Name,
    string Translation,
    DateTime? LearnedAt,
    DateTime? RepeatedAt,
    int LearnAttempts,
    string? CefrLevel,
    string[] Topics,
    WordTranslationDifficulty? Difficulty);
    
