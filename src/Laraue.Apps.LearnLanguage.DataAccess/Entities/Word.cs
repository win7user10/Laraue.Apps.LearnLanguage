using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Represents all words in the system in english
/// </summary>
public class Word : BaseEntity
{
    /// <summary>
    /// The word, e.g. cat, dog etc.
    /// </summary>
    [MaxLength(100)]
    public required string Name { get; init; }

    public required long? WordCefrLevelId { get; init; }
    
    /// <summary>
    /// Word cefr level, e.g A1, A2, B1 etc.
    /// </summary>
    public WordCefrLevel? WordCefrLevel { get; init; }

    public required long? WordTopicId { get; init; }
    
    /// <summary>
    /// Word topic, e.g animals, work, study etc.
    /// </summary>
    public WordTopic? WordTopic { get; init; }
}