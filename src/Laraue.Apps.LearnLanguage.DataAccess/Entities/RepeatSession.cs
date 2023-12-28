namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class RepeatSession : BaseEntity
{
    public Guid UserId { get; set; }
    
    public User User { get; set; }

    public ICollection<RepeatSessionWordTranslation> Words { get; set; }

    public RepeatState State { get; set; }

    public DateTime StartedAt { get; set; }
    
    public DateTime? FinishedAt { get; set; }
}

public enum RepeatState
{
    Filling,
    Active,
    Finished,
}