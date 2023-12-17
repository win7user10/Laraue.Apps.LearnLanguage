using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTranslationState : BaseEntity
{
    /// <summary>
    /// Users labels about this word.
    /// </summary>
    public LearnState LearnState { get; set; }
    
    /// <summary>
    /// How many times user viewed this word.
    /// </summary>
    public int ViewCount { get; set; }
    
    /// <summary>
    /// UTC date time when the word has been learned.
    /// </summary>
    public DateTime? LearnedAt { get; set; }
    
    public long WordTranslationId { get; set; }

    public WordTranslation WordTranslation { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}