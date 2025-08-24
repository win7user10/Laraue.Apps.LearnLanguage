namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class UserQuizQuestion : BaseEntity
{
    public long QuizId { get; set; }
    public UserQuiz Quiz { get; set; } = null!;
    
    public long TranslationId { get; set; }
    public Translation Translation { get; set; } = null!;
    
    public DateTime? AnsweredAt { get; set; }
    public UserQuizQuestionStatus Status { get; set; }

    /// <summary>
    /// Possible option ids for the question.
    /// </summary>
    public long[] OptionIds { get; set; } = [];
}

public enum UserQuizQuestionStatus
{
    New,
    Correct,
    Incorrect,
    Skipped,
}