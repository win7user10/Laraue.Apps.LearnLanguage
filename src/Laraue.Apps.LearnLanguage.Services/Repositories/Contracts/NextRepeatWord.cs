using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

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
    
