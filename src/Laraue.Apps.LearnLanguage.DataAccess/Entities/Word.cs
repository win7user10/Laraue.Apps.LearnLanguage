using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// It is any word could be met in the book.
/// <example>Cat (en), human (en), снег (ru)</example>
/// </summary>
public sealed class Word : BaseEntity
{
    /// <summary>
    /// The word, e.g. cat, dog etc.
    /// </summary>
    [MaxLength(100)]
    public required string Text { get; init; }

    /// <summary>
    /// The word transcription.
    /// </summary>
    [MaxLength(100)]
    public string? Transcription { get; init; }
    
    /// <summary>
    /// The reference to <see cref="Entities.WordLanguage"/>.
    /// </summary>
    public long LanguageId { get; set; }

    /// <summary>
    /// The word language.
    /// </summary>
    public WordLanguage Language { get; set; } = null!;
    
    public ICollection<TranslationState> TranslationStates { get; set; } = null!;
    public ICollection<MeaningTopic> Topics { get; set; } = null!;
    public ICollection<Meaning> Meanings { get; set; } = null!;
    public ICollection<RepeatSessionTranslation> RepeatSessionTranslations { get; set; } = null!;
    public ICollection<Translation> Translations { get; set; } = null!;
}