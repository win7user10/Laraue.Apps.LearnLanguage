using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.AppServices.Services;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class QuizController(IQuizService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.CurrentQuiz)]
    public Task HandleQuizWindowAsync(
        RequestContext context,
        [FromQuery] QuizRequest request,
        CancellationToken ct)
    {
        return service.HandleQuizWindowAsync(ReplyData.FromRequest(context), request, ct);
    }
}