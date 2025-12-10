namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public interface IQuizService
{
    Task HandleQuizWindowAsync(ReplyData replyData, QuizRequest request, CancellationToken ct = default);
}