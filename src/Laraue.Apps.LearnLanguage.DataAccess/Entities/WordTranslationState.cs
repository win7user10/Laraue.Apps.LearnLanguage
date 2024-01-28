namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTranslationState : BaseEntity
{
    /// <summary>
    /// How many times user seen this word before it was learned.
    /// </summary>
    public int LearnAttempts { get; set; }
    
    /// <summary>
    /// UTC date time when the word has been learned.
    /// </summary>
    public DateTime? LearnedAt { get; set; }
    
    public DateTime? RepeatedAt { get; set; }
    
    public long WordTranslationId { get; set; }

    public WordTranslation WordTranslation { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public DateTime LastOpenedAt { get; set; } = DateTime.MinValue;
    
    /// <summary>
    /// Users label for this word.
    /// </summary>
    public bool IsMarked { get; set; }
}