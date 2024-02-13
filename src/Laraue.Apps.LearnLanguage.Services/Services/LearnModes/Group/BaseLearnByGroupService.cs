using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public abstract class BaseLearnByGroupService<TId, TRequest>(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByGroupRepository<TId> repository)
    : ILearnByGroupService<TId, TRequest>
    where TRequest : BaseLearnByGroupRequest<TId>
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
        if (request.OpenedWordTranslationId is not null)
        {
            await wordsRepository.ChangeWordLearnStateAsync(
                replyData.UserId,
                request.OpenedWordTranslationId.Value,
                request.IsLearned,
                request.IsMarked,
                ct);
        }
        
        var userSettings = await userRepository.GetViewSettingsAsync(replyData.UserId, ct);
        var words = await repository.GetGroupWordsAsync(
            request.GroupId,
            replyData.UserId,
            userSettings.ShowWordsMode,
            new PaginatedRequest(request.Page, Constants.PaginationCount),
            ct);

        var viewRoute = new RoutePathBuilder(DetailRoute)
            .WithQueryParameter(ParameterNames.GroupId, request.GroupId)
            .WithQueryParameter(ParameterNames.Page, request.Page)
            .Freeze();
        
        var returnBackButton = new RoutePathBuilder(ListRoute)
            .ToInlineKeyboardButton(GroupMode.BackButton);

        var groupName = await repository.GetGroupNameAsync(request.GroupId, ct);
        
        var wordsWindow = wordsWindowFactory
            .Create(
                words: words,
                userViewSettings: userSettings,
                viewRoute: viewRoute)
            .SetWindowTitle($"{ModeName} - {groupName}")
            .SetBackButton(returnBackButton)
            .UseFilters();
        
        if (words.TryGetOpenedWord(request.OpenedWordTranslationId, out var openedWord))
        {
            wordsWindow.SetOpenedTranslation(openedWord);
            var switchLearnStateButton = viewRoute
                .WithQueryParameter(ParameterNames.LearnState, openedWord.LearnedAt is null)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(openedWord.LearnedAt is not null ? "Not learned ❌" : "Learned ✅");
        
            var switchIsHardButton = viewRoute
                .WithQueryParameter(ParameterNames.MarkState, !openedWord.IsMarked)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(openedWord.IsMarked ? "Drop mark" : "Add mark");

            wordsWindow.SetActionButtons(new[] { switchLearnStateButton, switchIsHardButton });
        }

        await wordsWindow.SendAsync(replyData, ct);
    }

    public async Task HandleListViewAsync(
        LearnListRequest learnListRequest,
        ReplyData replyData,
        CancellationToken ct = default)
    {
        if (learnListRequest.LanguageToLearnId is not null && learnListRequest.LanguageToLearnFromId is not null)
        {
            await HandleListViewAsync(
                learnListRequest,
                replyData,
                learnListRequest.LanguageToLearnId.Value,
                learnListRequest.LanguageToLearnFromId.Value,
                ct);
            
            return;
        }
        
        var settings = await userRepository.GetLanguageSettingsAsync(replyData.UserId, ct);
        if (settings is not null)
        {
            await HandleListViewAsync(
                learnListRequest,
                replyData,
                settings.LanguageIdToLearn,
                settings.LanguageIdToLearnFrom,
                ct);
            
            return;
        }

        await HandleSelectLanguageViewAsync(replyData, ct);
    }

    private async Task HandleSelectLanguageViewAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var availablePairs = await wordsRepository.GetAvailableLearningPairsAsync(ct);
        
        var listRoute = new RoutePathBuilder(ListRoute);
        
        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{ModeName}</b>")
            .AppendRow()
            .AppendRow($"Select the language pair to learn");

        tmb.AddInlineKeyboardButtons(availablePairs
            .Select(p => listRoute
                .WithQueryParameter(ParameterNames.LanguageToLearnFrom, p.LanguageToLearnFrom.Id)
                .WithQueryParameter(ParameterNames.LanguageToLearn, p.LanguageToLearn.Id)
                .ToInlineKeyboardButton($"{p.LanguageToLearnFrom.Code} -> {p.LanguageToLearn.Code}")));
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    private async Task HandleListViewAsync(
        LearnListRequest learnListRequest,
        ReplyData replyData,
        long languageToLearnId,
        long languageToLearnFromId,
        CancellationToken ct = default)
    {
        // TODO - groups only for the specified language
        var groups = await repository.GetGroupsAsync(replyData.UserId, ct);
        
        var learnedCount = groups.Sum(x => x.LearnedCount);
        var totalCount = groups.Sum(x => x.TotalCount);
        var completedPercent = learnedCount.DivideAndReturnPercent(totalCount);

        var detailRoute = new RoutePathBuilder(DetailRoute);

        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{ModeName}</b>")
            .AppendRow(string.Format(GroupMode.LearnedWords, $"{learnedCount}/{totalCount} ({completedPercent:F}%)"))
            .AppendRow();

        var groupsWithNumber = groups
            .Select((group, i) => new { Group = group, SerialNumber = i + 1 })
            .ToList();
        
        tmb.AppendRows(groupsWithNumber
            .Select(group
                => $"{group.SerialNumber}) {group.Group.Name} - {group.Group.LearnedCount}/{group.Group.TotalCount}" +
                   $" ({group.Group.LearnedCount.DivideAndReturnPercent(group.Group.TotalCount):F}%)"));
        
        tmb.AppendRow()
            .AppendRow(GroupMode.Open);

        foreach (var groupsChunk in groupsWithNumber.Chunk(Constants.PaginationCount))
        {
            tmb.AddInlineKeyboardButtons(groupsChunk
                .Select(group => detailRoute
                    .WithQueryParameter(ParameterNames.GroupId, group.Group.Id)
                    .ToInlineKeyboardButton(group.SerialNumber.ToString())));
        }

        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }
}