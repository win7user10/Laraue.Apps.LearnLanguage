using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group.Topic;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LearnByTopicController(ILearnByTopicService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.ListGroupsByTopic)]
    public Task HandleListRequestAsync(
        RequestContext request,
        [FromQuery] OpenModeRequest openModeRequest,
        CancellationToken ct)
    {
        return service.HandleListViewAsync(openModeRequest, ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.DetailGroupByTopic)]
    public Task HandleDetailRequestAsync(
        RequestContext context,
        [FromQuery] DetailViewByTopicRequest detailViewByGroup,
        CancellationToken ct)
    {
        return service.HandleDetailViewAsync(
            ReplyData.FromRequest(context),
            detailViewByGroup,
            ct);
    }
}