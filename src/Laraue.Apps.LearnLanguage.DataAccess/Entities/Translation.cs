using System.ComponentModel.DataAnnotations;
using Laraue.Apps.LearnLanguage.Contracts.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class Translation : IEntityWithWordReference
{
    public long WordId { get; init; }
    public Word Word { get; set; }
    
    public ICollection<LearnedTranslation> LearnedTranslations { get; set; } = null!;

    /// <summary>
    /// Translation text.
    /// </summary>
    [MaxLength(150)]
    public string Text { get; set; } = string.Empty;
    
    /// <summary>
    /// The reference to <see cref="WordLanguage"/>.
    /// </summary>
    public long LanguageId { get; set; }

    /// <summary>
    /// The language of the translation.
    /// </summary>
    public WordLanguage Language { get; set; } = null!;
    
    /// <summary>
    /// Transcription of the translation.
    /// </summary>
    public string? Transcription { get; set; }

    #region Computed Fields

    /// <summary>
    /// Average attempts required to learn this translation.
    /// </summary>
    public double? AverageAttempts { get; set; }

    /// <summary>
    /// Word translation learn difficulty based on <see cref="AverageAttempts"/>.
    /// </summary>
    public WordTranslationDifficulty? Difficulty { get; set; }

    #endregion
}