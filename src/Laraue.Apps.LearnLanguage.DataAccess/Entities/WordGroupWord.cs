namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// One word of the user created <see cref="WordGroup"/>.
/// </summary>
public class WordGroupWord : BaseEntity
{
    /// <summary>
    /// Sequential number of the word in the group.
    /// </summary>
    public long SerialNumber { get; init; }

    /// <summary>
    /// The group the word is belongs to.
    /// </summary>
    public long WordGroupId { get; set; }
    
    public long WordTranslationId { get; set; }

    /// <summary>
    /// Link to the <see cref="WordGroup"/>.
    /// </summary>
    public WordGroup WordGroup { get; set; } = default!;
    
    /// <summary>
    /// Link to the <see cref="WordTranslation"/>.
    /// </summary>
    public WordTranslation WordTranslation { get; set; } = default!;

    public WordTranslationState WordTranslationState { get; set; }
}