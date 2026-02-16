namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// The CEFR levels selected for quiz's. All quiz questions will be related to these CEFR levels.
/// </summary>
public class UserQuizTopic
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public long TopicId { get; set; }
    public Topic Topic { get; set; } = null!;
}