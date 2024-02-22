using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Relation between <see cref="WordTranslation"/> and <see cref="RepeatSession"/>.
/// </summary>
public sealed class RepeatSessionWordTranslation : BaseEntity
{
    /// <summary>
    /// The <see cref="WordTranslation"/> reference.
    /// </summary>
    public long WordTranslationId { get; set; }

    /// <summary>
    /// One of the translations to repeat in the session.
    /// </summary>
    public WordTranslation WordTranslation { get; set; } = null!;
    
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
}