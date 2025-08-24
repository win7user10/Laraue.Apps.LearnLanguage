namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class LearnedTranslation : BaseEntity
{
    public Translation Translation { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = new();

    public int WinStreakCount { get; set; }
    public DateTime? LearnedAt { get; set; }
}