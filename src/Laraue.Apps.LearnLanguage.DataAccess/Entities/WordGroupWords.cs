using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// One word of the user created <see cref="WordGroup"/>.
/// </summary>
public class WordGroupWords : BaseEntity
{
    /// <summary>
    /// Sequential number of the word in the group.
    /// </summary>
    public long SerialNumber { get; init; }

    /// <summary>
    /// The group the word is belongs to.
    /// </summary>
    public long WordGroupId { get; set; }
    
    /// <summary>
    /// Link to the <see cref="WordGroup"/>.
    /// </summary>
    public WordGroup WordGroup { get; set; }

    /// <summary>
    /// Users labels about this word.
    /// </summary>
    public LearnState LearnState { get; set; }
    
    public long WordTranslationId { get; set; }
    
    public WordTranslation WordTranslation { get; set; }
    
    /// <summary>
    /// How many times user viewed this word.
    /// </summary>
    public int ViewCount { get; set; }
    
    /// <summary>
    /// UTC date time when the word has been learned.
    /// </summary>
    public DateTimeOffset? LearnedAt { get; set;}
}