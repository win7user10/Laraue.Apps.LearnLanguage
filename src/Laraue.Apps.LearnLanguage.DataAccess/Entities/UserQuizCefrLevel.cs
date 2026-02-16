namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// The CEFR levels selected for quiz's. All quiz questions will be related to these CEFR levels.
/// </summary>
public class UserQuizCefrLevel
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public long CefrLevelId { get; set; }
    public CefrLevel CefrLevel { get; set; } = null!;
}