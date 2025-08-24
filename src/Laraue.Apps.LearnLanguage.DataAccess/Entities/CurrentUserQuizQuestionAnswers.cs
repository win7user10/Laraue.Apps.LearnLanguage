namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class CurrentUserQuizQuestionAnswers
{
    public Guid UserId { get; set; }
    public long[] OptionIds { get; set; } = [];
    public long OptionId  { get; set; }
}