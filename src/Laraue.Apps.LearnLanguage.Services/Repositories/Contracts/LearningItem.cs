using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearningItem(
    string Word,
    string Translation,
    long SerialNumber,
    bool IsMarked,
    WordTranslationDifficulty? Difficulty,
    long TranslationId,
    string? CefrLevel,
    string? Topic,
    DateTime? LearnedAt,
    DateTime? RepeatedAt);