namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// A relation between <see cref="WordMeaning"/> and <see cref="WordTopic"/>.
/// </summary>
public sealed class WordMeaningTopic : BaseEntity
{
    /// <summary>
    /// <see cref="WordMeaning"/> reference.
    /// </summary>
    public long WordMeaningId { get; set; }

    /// <summary>
    /// The word meaning related to the meaning.
    /// </summary>
    public WordMeaning WordMeaning { get; set; } = null!;

    /// <summary>
    /// The <see cref="WordTopic"/> reference.
    /// </summary>
    public required long WordTopicId { get; init; }
    
    /// <summary>
    /// Word topic, e.g animals, work, study etc.
    /// </summary>
    public WordTopic WordTopic { get; init; } = null!;
}