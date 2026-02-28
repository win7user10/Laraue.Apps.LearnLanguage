using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.AppServices.Services;
using Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StartController(IMenuService service) : TelegramController
{
    [TelegramMessageRoute(TelegramRoutes.Start)]
    public Task StartAsync(RequestContext request, CancellationToken cancellationToken)
    {
        return service.StartAsync(
            request.Update.Message!.Text!,
            request.UserId,
            request.Update.GetUserId(),
            cancellationToken);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Start, RouteMethod.Post)]
    public Task ApplyStartSettingsAsync(
        RequestContext context,
        [FromQuery] ApplyStartSettingsRequest request,
        CancellationToken cancellationToken)
    {
        return service.HandleApplyStartSettingsAsync(
            request,
            ReplyData.FromRequest(context),
            cancellationToken);
    }
}