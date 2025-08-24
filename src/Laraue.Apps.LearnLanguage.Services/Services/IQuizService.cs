using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IQuizService
{
    Task HandleQuizWindowAsync(ReplyData replyData, CancellationToken ct = default);
    Task HandleStartQuizAsync(ReplyData replyData, OpenModeRequest request, CancellationToken ct = default);
}