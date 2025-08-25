namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// A relation between <see cref="Entities.Meaning"/> and <see cref="Topic"/>.
/// </summary>
public sealed class WordTopic : IEntityWithWordReference
{
    public long WordId { get; init; }
    
    public Word Word { get; set; }
    
    /// <summary>
    /// The <see cref="Topic"/> reference.
    /// </summary>
    public required long TopicId { get; init; }
    
    /// <summary>
    /// Word topic, e.g animals, work, study etc.
    /// </summary>
    public Topic Topic { get; init; } = null!;
}