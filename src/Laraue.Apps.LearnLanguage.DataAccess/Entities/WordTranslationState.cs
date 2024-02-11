﻿namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTranslationState : BaseEntity
{
    /// <summary>
    /// How many times user seen this word before it was learned.
    /// </summary>
    public int LearnAttempts { get; set; }
    
    /// <summary>
    /// UTC date time when the translation has been learned.
    /// </summary>
    public DateTime? LearnedAt { get; set; }
    
    /// <summary>
    /// UTC date time when the translation has been repeated.
    /// </summary>
    public DateTime? RepeatedAt { get; set; }
    
    /// <summary>
    /// The reference to <see cref="WordTranslation"/>.
    /// </summary>
    public long WordTranslationId { get; set; }

    /// <summary>
    /// The word translation.
    /// </summary>
    public WordTranslation WordTranslation { get; set; } = null!;
    
    /// <summary>
    /// The reference to <see cref="User"/>.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User the state belongs to.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Last time the <see cref="User"/> opened this translation.
    /// </summary>
    public DateTime LastOpenedAt { get; set; } = DateTime.MinValue;
    
    /// <summary>
    /// Is true when the user marked the word.
    /// </summary>
    public bool IsMarked { get; set; }
}