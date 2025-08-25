namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class LearnedTranslation : IEntityWithTranslationReference
{
    public long WordId { get; set; }
    public long LanguageId { get; set; }
    public Translation Translation { get; set; } = null!;
    public Word Word { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public int WinStreakCount { get; set; }
    public DateTime? LearnedAt { get; set; }
}