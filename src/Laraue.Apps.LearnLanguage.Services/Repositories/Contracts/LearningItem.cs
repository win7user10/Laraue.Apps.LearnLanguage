using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearningItem
{
    public string Word { get; init; }
    public string Translation { get; init; }
    public string? Transcription { get; init; }
    public string? Meaning { get; init; }
    public bool IsMarked { get; init; }
    public WordTranslationDifficulty? Difficulty { get; init; }
    public TranslationIdentifier TranslationId { get; init; }
    public string? CefrLevel { get; init; }
    public List<string> Topics { get; init; }
    public DateTime? LearnedAt { get; init; }
    public DateTime? RepeatedAt { get; init; }
}