using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearningItem(
    string Word,
    string Translation,
    long SerialNumber,
    LearnState LearnState,
    WordTranslationDifficulty? Difficulty,
    long TranslationId,
    DateTime? LearnedAt);