using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LanguageController : TelegramController
{
    private readonly IWordsService _wordsService;

    public LanguageController(IWordsService wordsService)
    {
        _wordsService = wordsService;
    }

    [TelegramCallbackRoute(TelegramRoutes.Groups)]
    public Task SendGroupsAsync(RequestContext request, [FromQuery] int p, CancellationToken ct)
    {
        return _wordsService.SendWordGroupsAsync(
            ReplyData.FromRequest(request),
            page: p,
            ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Group)]
    public Task SendGroupAsync(
        RequestContext request,
        [FromQuery] int p,
        [FromQuery(ParameterNames.GroupId)] long groupId,
        [FromQuery(ParameterNames.RevertTranslations)] bool toggleRevertTranslations,
        [FromQuery(ParameterNames.ToggleTranslations)] bool toggleShowTranslations,
        [FromQuery(ParameterNames.ShowMode)] ShowWordsMode? showMode,
        [FromQuery(ParameterNames.OpenedWordId)] int? openedWordId,
        [FromQuery(ParameterNames.LearnState)] LearnState? learnState)
    {
        return _wordsService.SendWordsAsync(
            ReplyData.FromRequest(request),
            groupId,
            page: p,
            new IWordsService.ChangeViewSettings
            {
                LearnState = learnState,
                ToggleRevertTranslations = toggleRevertTranslations,
                ToggleShowTranslations = toggleShowTranslations,
                OpenedWordTranslationId = openedWordId,
                ShowMode = showMode
            });
    }
}