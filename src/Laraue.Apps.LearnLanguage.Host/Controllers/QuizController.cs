using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class QuizController(IQuizService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.QuizSetup)]
    public Task HandleQuizWindowAsync(
        RequestContext context,
        [FromQuery] OpenModeRequest request,
        CancellationToken ct)
    {
        return service.HandleQuizWindowAsync(ReplyData.FromRequest(context), ct);
    }
    
    
    [TelegramCallbackRoute(TelegramRoutes.StartQuiz)]
    public Task HandleStartQuizAsync(
        RequestContext context,
        [FromQuery] OpenModeRequest request,
        CancellationToken ct)
    {
        return service.HandleStartQuizAsync(ReplyData.FromRequest(context), request, ct);
    }
}