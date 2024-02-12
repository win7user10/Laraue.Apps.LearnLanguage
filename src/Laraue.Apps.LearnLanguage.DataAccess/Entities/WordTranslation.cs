using System.ComponentModel.DataAnnotations;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class WordTranslation : BaseEntity
{
    /// <summary>
    /// The reference to <see cref="Entities.WordMeaning"/>.
    /// </summary>
    public long WordMeaningId { get; set; }

    /// <summary>
    /// The meaning of the translation.
    /// </summary>
    public WordMeaning WordMeaning { get; set; } = null!;

    /// <summary>
    /// Translation text.
    /// </summary>
    [MaxLength(100)]
    public string Translation { get; set; } = string.Empty;
    
    /// <summary>
    /// The reference to <see cref="WordLanguage"/>.
    /// </summary>
    public long LanguageId { get; set; }

    /// <summary>
    /// The language of the translation.
    /// </summary>
    public WordLanguage Language { get; set; } = null!;

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