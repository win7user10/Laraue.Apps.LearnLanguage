namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class UserQuiz : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public long LanguageId { get; set; }
    public WordLanguage Language { get; set; } = null!;
    public UserQuizStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}

public enum UserQuizStatus
{
    Active,
    Finished,
    Cancelled,
}