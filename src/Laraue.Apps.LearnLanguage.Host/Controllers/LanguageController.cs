using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LanguageController(ISequentialModeService sequentialModeService, IRepeatModeService repeatModeService) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.Groups)]
    public Task SendGroupsAsync(RequestContext request, [FromQuery] int p, CancellationToken ct)
    {
        return sequentialModeService.SendGroupsViewAsync(
            ReplyData.FromRequest(request),
            page: p,
            ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Group)]
    public Task SendGroupAsync(
        RequestContext request,
        [FromQuery] int p,
        [FromQuery] ChangeUserSettings changeUserSettings,
        [FromQuery(ParameterNames.GroupId)] long groupId,
        [FromQuery(ParameterNames.OpenedTranslationId)] int? openedWordId,
        [FromQuery(ParameterNames.LearnState)] LearnState? learnState)
    {
        return sequentialModeService.HandleSequentialWindowWordsViewAsync(
            ReplyData.FromRequest(request),
            groupId,
            page: p,
            request: changeUserSettings,
            openedWordTranslationId: openedWordId,
            learnState: learnState);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.RepeatWindow)]
    public Task SendRepeatingWindowAsync(RequestContext request, CancellationToken ct)
    {
        return repeatModeService.SendRepeatingWindowAsync(ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.HandleSuggestion)]
    public Task HandleSuggestionAsync(RequestContext context, [FromQuery] HandleWordRequest request, CancellationToken ct)
    {
        return repeatModeService.HandleSuggestedWordAsync(
            ReplyData.FromRequest(context),
            request,
            ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.RepeatWindowWordsView)]
    public Task SendRepeatingWindowsWordsAsync(
        RequestContext context,
        [FromQuery] ChangeUserSettings request,
        [FromQuery(ParameterNames.Page)] int page,
        [FromQuery(ParameterNames.SessionId)] long sessionId,
        [FromQuery(ParameterNames.OpenedTranslationId)] long? openedTranslationId,
        [FromQuery(ParameterNames.RememberState)] bool rememberState,
        CancellationToken ct)
    {
        return repeatModeService.HandleRepeatingWindowWordsViewAsync(
            ReplyData.FromRequest(context),
            sessionId,
            request,
            page,
            openedTranslationId,
            rememberState,
            ct);
    }
}