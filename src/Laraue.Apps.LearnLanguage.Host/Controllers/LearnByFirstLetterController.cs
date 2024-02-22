using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LearnByFirstLetterController(ILearnByFirstLetterService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.ListGroupsByFirstLetter)]
    public Task HandleListRequestAsync(
        RequestContext request,
        [FromQuery] OpenModeRequest openModeRequest,
        CancellationToken ct)
    {
        return service.HandleListViewAsync(openModeRequest, ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.DetailGroupByFirstLetter)]
    public Task HandleDetailRequestAsync(
        RequestContext context,
        [FromQuery] DetailViewByFirstLetterRequest detailViewByGroup,
        CancellationToken ct)
    {
        return service.HandleDetailViewAsync(
            ReplyData.FromRequest(context),
            detailViewByGroup,
            ct);
    }
}