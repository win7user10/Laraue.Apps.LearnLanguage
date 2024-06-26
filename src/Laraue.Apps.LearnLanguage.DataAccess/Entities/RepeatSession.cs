﻿using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class RepeatSession : BaseEntity
{
    /// <summary>
    /// The <see cref="User"/> reference.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User the session belongs to.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Translations in the session.
    /// </summary>
    public ICollection<RepeatSessionTranslation> Words { get; set; } = null!;

    /// <summary>
    /// The session current state.
    /// </summary>
    public RepeatState State { get; set; }

    /// <summary>
    /// When the session has been started.
    /// </summary>
    public DateTime StartedAt { get; set; }
    
    /// <summary>
    /// When the session has been finished.
    /// </summary>
    public DateTime? FinishedAt { get; set; }

    /// <summary>
    /// The <see cref="WordLanguage"/> reference.
    /// </summary>
    public long? LanguageToLearnId { get; set; }

    /// <summary>
    /// Language that was learned in the session.
    /// </summary>
    public WordLanguage LanguageToLearn { get; set; } = null!;

    /// <summary>
    /// The <see cref="WordLanguage"/> reference.
    /// </summary>
    public long? LanguageToLearnFromId { get; set; }

    /// <summary>
    /// Language that was used as native when while learning.
    /// </summary>
    public WordLanguage LanguageToLearnFrom { get; set; } = null!;
}