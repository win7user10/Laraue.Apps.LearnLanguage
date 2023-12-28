using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class SequentialModeService(
    IUserRepository userRepository,
    ITelegramBotClient client,
    ISequentialModeRepository sequentialModeRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory)
    : ISequentialModeService
{
    public async Task SendGroupsViewAsync(ReplyData replyData, int page, CancellationToken ct = default)
    {
        var result = await sequentialModeRepository.GetGroupsAsync(
            replyData.UserId,
            new PaginatedRequest(page, Constants.PaginationCount),
            ct);
        
        var learnedCount = result.Data.Sum(x => x.LearnedCount);
        var totalCount = result.Data.Sum(x => x.TotalCount);
        var completedPercent = learnedCount.DivideAndReturnPercent(totalCount);

        var groupRoute = new RoutePathBuilder(TelegramRoutes.Group);

        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>Word groups. Page {result.Page + 1}/{result.LastPage + 1}.</b>")
            .AppendRow($"Learned words: {learnedCount}/{totalCount} ({completedPercent:F}%)")
            .AppendRow("")
            .AppendDataRows(result, (x, _) => $"{x.SerialNumber}) {x.FirstWord}-* {x.LearnedCount}/{x.TotalCount}")
            .AppendRow("")
            .AppendRow("Open group: ")
            .AddInlineKeyboardButtons(result, (x, i) => InlineKeyboardButton.WithCallbackData(
                x.SerialNumber.ToString(),
                groupRoute
                    .WithQueryParameter(ParameterNames.GroupId, x.Id)))
            .AddPaginationButtons(result, new RoutePathBuilder(TelegramRoutes.Groups))
            .AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
        await userRepository.UpdateLastViewedTranslationsAsync(replyData.UserId, Array.Empty<long>(), ct);
    }

    public async Task HandleSequentialWindowWordsViewAsync(
        ReplyData replyData,
        long groupId,
        int page,
        ChangeUserSettings request,
        long? openedWordTranslationId,
        LearnState? learnState,
        CancellationToken ct = default)
    {
        await userRepository.UpdateViewSettings(replyData.UserId, request, ct);
        if (learnState is not null && openedWordTranslationId is not null)
        {
            await wordsRepository.ChangeWordLearnStateAsync(
                replyData.UserId,
                openedWordTranslationId.GetValueOrDefault(),
                learnState.GetValueOrDefault(),
                ct);
        }
        
        var userSettings = await userRepository.GetSettingsAsync(replyData.UserId, ct);
        var words = await sequentialModeRepository.GetGroupWordsAsync(
            groupId,
            userSettings.ShowWordsMode,
            new PaginatedRequest(page, Constants.PaginationCount),
            ct);
        
        var closestGroups = await sequentialModeRepository
            .GetClosestUnlearnedGroupsAsync(groupId, ct);

        var groupSerialNumber = await sequentialModeRepository.GetGroupSerialNumberAsync(groupId, ct);
        
        var shouldNumberBeSubtracted = groupSerialNumber % Constants.PaginationCount == 0;
        var pageNumber = groupSerialNumber / Constants.PaginationCount - (shouldNumberBeSubtracted ? 1 : 0);
        
        var returnBackButton = InlineKeyboardButton.WithCallbackData(
            "Return to the groups list 🔙",
            new RoutePathBuilder(TelegramRoutes.Groups)
                .WithQueryParameter(ParameterNames.Page, pageNumber));

        var groupRoute = new RoutePathBuilder(TelegramRoutes.Group)
            .WithQueryParameter(ParameterNames.GroupId, groupId)
            .WithQueryParameter(ParameterNames.Page, page);

        var routeBuilder = new RoutePathBuilder(TelegramRoutes.Group).Freeze();

        InlineKeyboardButton? previousGroupButton = null;
        InlineKeyboardButton? nextGroupButton = null;
        
        if (closestGroups.PreviousGroupId is not null)
        {
            previousGroupButton = routeBuilder
                .WithQueryParameter(ParameterNames.GroupId, closestGroups.PreviousGroupId)
                .ToInlineKeyboardButton("Previous group ⬅");
        }
        
        if (!words.HasNextPage && closestGroups.NextGroupId is not null)
        {
            nextGroupButton = routeBuilder
                .WithQueryParameter(ParameterNames.GroupId, closestGroups.NextGroupId)
                .ToInlineKeyboardButton("Next group ➡");
        }

        var fallbackButtons = new ControlButtons(previousGroupButton, nextGroupButton);

        var wordsWindow = wordsWindowFactory
            .Create(
                words: words,
                userSettings: userSettings,
                viewRoute: groupRoute)
            .SetWindowTitle($"Words of group {groupSerialNumber}")
            .SetBackButton(returnBackButton)
            .SetPaginationRoute(routeBuilder.WithQueryParameter(ParameterNames.GroupId, groupId))
            .SetFallbackPaginationButtons(fallbackButtons)
            .UseFilters();

        if (words.TryGetOpenedWord(openedWordTranslationId, out var openedWord))
        {
            wordsWindow.SetOpenedTranslation(openedWord);
            var isLearned = openedWord.LearnState.HasFlag(LearnState.Learned);
            var switchLearnStateButton = groupRoute
                .WithQueryParameter(ParameterNames.LearnState, LearnState.Learned)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(isLearned ? "Not learned ❌" : "Learned ✅");
        
            var isHard = openedWord.LearnState.HasFlag(LearnState.Hard);
            var switchIsHardButton = groupRoute
                .WithQueryParameter(ParameterNames.LearnState, LearnState.Hard)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(isHard ? "Easy " : "Hard 🧠");

            wordsWindow.SetActionButtons(new[] { switchLearnStateButton, switchIsHardButton });
        }

        await wordsWindow.SendAsync(replyData, ct);
    }
}