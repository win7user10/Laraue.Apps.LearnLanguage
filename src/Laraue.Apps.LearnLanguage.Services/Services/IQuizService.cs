namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IQuizService
{
    Task HandleQuizWindowAsync(ReplyData replyData, QuizRequest request, CancellationToken ct = default);
}