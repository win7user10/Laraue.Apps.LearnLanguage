using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// One of the <see cref="Word"/> meanings.
/// </summary>
public sealed class Meaning : BaseEntity, IEntityWithWordReference
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
    [MaxLength(150)]
    public string? Text { get; set; }
    
    /// <summary>
    /// The reference to <see cref="CefrLevel"/>.
    /// </summary>
    public required long? CefrLevelId { get; init; }
    
    /// <summary>
    /// The meaning cefr level, e.g A1, A2, B1 etc.
    /// </summary>
    public CefrLevel? CefrLevel { get; init; }

    /// <summary>
    /// The table with <see cref="Topic"/> references.
    /// </summary>
    public ICollection<MeaningTopic> Topics { get; set; } = null!;
    
    /// <summary>
    /// List of <see cref="Translation"/> related to the meaning. 
    /// </summary>
    public ICollection<Translation> Translations { get; set; } = null!;
    
    public ICollection<TranslationState> TranslationStates { get; set; } = null!;
    public ICollection<RepeatSessionTranslation> RepeatSessionTranslations { get; set; } = null!;
}