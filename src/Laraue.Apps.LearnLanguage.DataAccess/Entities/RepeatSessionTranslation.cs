using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Relation between <see cref="Entities.Translation"/> and <see cref="RepeatSession"/>.
/// </summary>
public sealed class RepeatSessionTranslation : IEntityWithTranslationReference
{
    public long WordId { get; init; }
    public Word Word { get; set; }
    public long MeaningId { get; init; }
    public Meaning Meaning { get; set; }
    public long TranslationId { get; init; }
    public Translation Translation { get; set; }
    
    /// <summary>
    /// The <see cref="RepeatSession"/> reference.
    /// </summary>
    public long RepeatSessionId { get; set; }

    /// <summary>
    /// One of the user repeat sessions.
    /// </summary>
    public RepeatSession RepeatSession { get; set; } = default!;

    /// <summary>
    /// Current state of the repeating.
    /// </summary>
    public RepeatSessionWordState RepeatSessionWordState { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}