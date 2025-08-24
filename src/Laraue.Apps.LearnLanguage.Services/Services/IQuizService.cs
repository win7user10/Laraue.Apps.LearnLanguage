using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IQuizService
{
    Task HandleQuizWindowAsync(ReplyData replyData, OpenModeRequest request, CancellationToken ct = default);
}