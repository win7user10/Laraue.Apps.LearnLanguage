namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class UserQuiz : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = new();
    public long LanguageId { get; set; }
    public WordLanguage Language { get; set; } = new();
    public UserQuizStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}

public enum UserQuizStatus
{
    Active,
    Finished,
    Cancelled,
}