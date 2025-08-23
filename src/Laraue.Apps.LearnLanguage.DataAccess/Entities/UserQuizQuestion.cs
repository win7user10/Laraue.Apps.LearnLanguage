namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class UserQuizQuestion : BaseEntity
{
    public long QuizId { get; set; }
    public UserQuiz Quiz { get; set; } = new();
    
    public long TranslationId { get; set; }
    public Translation Translation { get; set; } = new();
    
    public DateTime? AnsweredAt { get; set; }
    public UserQuizQuestionStatus? Status { get; set; }
}

public enum UserQuizQuestionStatus
{
    Correct,
    Incorrect,
    Skipped,
}