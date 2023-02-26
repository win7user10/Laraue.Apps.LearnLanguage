using Laraue.Apps.LearnLanguage.Commands;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Telegram.NET.Authentication.Services;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LanguageController : TelegramController
{
    private readonly IMediator _mediator;

    public LanguageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [TelegramCallbackRoute(TelegramRoutes.Groups + "*")]
    public Task SendGroupsAsync(RequestContext requestContext)
    {
        var parameters = requestContext.Update.CallbackQuery!.Data.ParseQueryParts();
        
        return _mediator.Send(new SendWordGroupsCommand
        {
            Page = parameters.GetPage(),
            Data = requestContext.Update.CallbackQuery,
            UserId = requestContext.UserId,
        });
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Group + "*")]
    public Task SendGroupAsync(RequestContext requestContext)
    {
        var parameters = requestContext.Update.CallbackQuery!.Data.ParseQueryParts();
        
        return _mediator.Send(new SendWordGroupWordsCommand
        {
            Page = parameters.GetPage(),
            Data = requestContext.Update.CallbackQuery!,
            UserId = requestContext.UserId,
            GroupId = parameters.GetValueOrDefault<long>(RenderWordsViewCommand.ParameterNames.GroupId),
            ToggleRevertTranslations = parameters.GetValueOrDefault<bool>(RenderWordsViewCommand.ParameterNames.RevertTranslations),
            ToggleShowTranslations = parameters.GetValueOrDefault<bool>(RenderWordsViewCommand.ParameterNames.ToggleTranslations),
            ShowMode = parameters.GetValueOrDefault<ShowWordsMode?>(RenderWordsViewCommand.ParameterNames.ShowMode),
            OpenedWordTranslationId = parameters.GetValueOrDefault<int?>(RenderWordsViewCommand.ParameterNames.OpenedWordId),
            LearnState = parameters.GetValueOrDefault<LearnState?>(RenderWordsViewCommand.ParameterNames.LearnState)
        });
    }
}