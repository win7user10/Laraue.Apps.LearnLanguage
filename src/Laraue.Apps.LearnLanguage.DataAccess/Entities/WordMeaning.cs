namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// One of the <see cref="Word"/> meanings.
/// </summary>
public sealed class WordMeaning : BaseEntity
{
    /// <summary>
    /// The <see cref="Word"/> reference.
    /// </summary>
    public long WordId { get; set; }

    /// <summary>
    /// The word related to the meaning.
    /// </summary>
    public Word Word { get; set; } = null!;

    /// <summary>
    /// The word meaning on the language of the word.
    /// </summary>
    public string? Meaning { get; set; }
    
    /// <summary>
    /// The reference to <see cref="WordCefrLevel"/>.
    /// </summary>
    public required long? WordCefrLevelId { get; init; }
    
    /// <summary>
    /// The meaning cefr level, e.g A1, A2, B1 etc.
    /// </summary>
    public WordCefrLevel? WordCefrLevel { get; init; }
}