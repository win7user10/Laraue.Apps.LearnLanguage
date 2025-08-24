namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class LearnedTranslation : BaseEntity
{
    public long TranslationId { get; set; }
    public Translation Translation { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public int WinStreakCount { get; set; }
    public DateTime? LearnedAt { get; set; }
}