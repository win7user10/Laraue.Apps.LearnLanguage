using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public abstract class BaseLearnByGroupService<TId, TRequest>(
    IUserRepository userRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByGroupRepository<TId> repository,
    ISelectLanguageService selectLanguageService)
    : ILearnByGroupService<TId, TRequest>
    where TRequest : DetailViewByGroupRequest<TId>
    where TId : struct
{
    /// <summary>
    /// Telegram route of the service view.
    /// </summary>
    protected abstract string ListRoute { get; }
    
    protected abstract string DetailRoute { get; }
    
    /// <summary>
    /// Title for the window.
    /// </summary>
    protected abstract string ModeName { get; }

    /// <inheritdoc />
    public async Task HandleDetailViewAsync(ReplyData replyData, TRequest request, CancellationToken ct = default)
    {
        await userRepository.UpdateViewSettings(replyData.UserId, request, ct);
        request.TryGetTranslationIdentifier(out var identifier);
        
        var userSettings = await userRepository.GetViewSettingsAsync(replyData.UserId, ct);
        var words = await repository.GetGroupWordsAsync(
            request.GroupId,
            replyData.UserId,
            userSettings.ShowWordsMode,
            new PaginatedRequest(request.Page, Constants.PaginationCount),
            request,
            ct);

        var viewRoute = new CallbackRoutePath(DetailRoute)
            .WithQueryParameter(ParameterNames.GroupId, request.GroupId)
            .WithQueryParameter(ParameterNames.Page, request.Page)
            .WithTranslationDirection(request)
            .Freeze();
        
        var returnBackButton = new CallbackRoutePath(ListRoute)
            .WithTranslationDirection(request)
            .ToInlineKeyboardButton(GroupMode.BackButton);

        var groupName = await repository.GetGroupNameAsync(request.GroupId, ct);
        
        var wordsWindow = wordsWindowFactory
            .Create(
                words: words,
                userViewSettings: userSettings,
                viewRoute: viewRoute)
            .SetWindowTitle($"{ModeName} - {groupName}")
            .SetBackButton(returnBackButton);
        
        if (words.TryGetOpenedWord(identifier, out var openedWord))
        {
            wordsWindow.SetOpenedTranslation(openedWord);
        }

        await wordsWindow.SendAsync(replyData, ct);
    }

    public Task HandleListViewAsync(
        OpenModeRequest openModeRequest,
        ReplyData replyData,
        CancellationToken ct = default)
    {
        return selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
            request: openModeRequest,
            languageWindowTitle: ModeName,
            nextRoute: ListRoute,
            replyData: replyData,
            handleRequestAsync: HandleListViewAsync,
            ct);
    }

    private async Task HandleListViewAsync(
        OpenModeRequest request,
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var groupsResult = await repository.GetGroupsAsync(
            replyData.UserId, selectedTranslation, request, ct);

        var groups = groupsResult.Data;

        var detailRoute = new CallbackRoutePath(DetailRoute)
            .WithTranslationDirection(selectedTranslation);

        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{ModeName}</b>")
            .AppendRow();

        var groupsWithNumber = groups
            .Select((group, i) => new { Group = group, SerialNumber = i + 1 })
            .ToList();
        
        tmb.AppendRows(groupsWithNumber
            .Select(group
                => $"{group.SerialNumber}) {group.Group.Name} - {group.Group.LearnedCount}/{group.Group.TotalCount}"));
        
        tmb.AppendRow()
            .AppendRow(GroupMode.Open);

        foreach (var groupsChunk in groupsWithNumber.Chunk(Constants.PaginationCount))
        {
            tmb.AddInlineKeyboardButtons(groupsChunk
                .Select(group => detailRoute
                    .WithQueryParameter(ParameterNames.GroupId, group.Group.Id)
                    .ToInlineKeyboardButton(group.SerialNumber.ToString())));
        }

        tmb.AddPaginationButtons(groupsResult, new CallbackRoutePath(ListRoute)
            .WithTranslationDirection(selectedTranslation));
        
        tmb
            .AddBackMenuButton(TelegramRoutes.ViewWordsListMenu)
            .AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }
}