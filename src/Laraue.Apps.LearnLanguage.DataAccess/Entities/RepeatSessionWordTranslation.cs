namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class RepeatSessionWordTranslation : BaseEntity
{
    public long WordTranslationId { get; set; }
    
    public WordTranslation WordTranslation { get; set; }
    
    public long RepeatSessionId { get; set; }

    public RepeatSession RepeatSession { get; set; }

    public RepeatSessionWordState RepeatSessionWordState { get; set; }
}

public enum RepeatSessionWordState
{
    NotRepeated,
    RepeatedSinceFirstAttempt,
    Repeated
}