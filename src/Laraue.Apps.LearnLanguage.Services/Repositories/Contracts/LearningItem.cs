using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearningItem(
    string Word,
    string Translation,
    string? Meaning,
    long SerialNumber,
    bool IsMarked,
    WordTranslationDifficulty? Difficulty,
    long TranslationId,
    string? CefrLevel,
    string[] Topics,
    DateTime? LearnedAt,
    DateTime? RepeatedAt);