using System.Text;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Extensions;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class WordsService : IWordsService
{
    private readonly IUserRepository _userRepository;
    private readonly IWordsRepository _wordsRepository;
    private readonly IStatsRepository _statsRepository;
    private readonly ITelegramBotClient _client;

    public WordsService(
        IUserRepository userRepository,
        ITelegramBotClient client,
        IWordsRepository wordsRepository,
        IStatsRepository statsRepository)
    {
        _userRepository = userRepository;
        _client = client;
        _wordsRepository = wordsRepository;
        _statsRepository = statsRepository;
    }

    public async Task SendWordGroupsAsync(ReplyData replyData, int page, CancellationToken ct = default)
    {
        var result = await _wordsRepository.GetGroupsAsync(
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

        await _client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
        await _userRepository.UpdateLastViewedTranslationsAsync(replyData.UserId, Array.Empty<long>(), ct);
    }

    public async Task SendWordsAsync(
        ReplyData replyData,
        long groupId,
        int page,
        IWordsService.ChangeViewSettings request,
        CancellationToken ct = default)
    {
        if (request.ToggleShowTranslations)
        {
            await _userRepository.ToggleWordsTemplateModeAsync(
                replyData.UserId,
                WordsTemplateMode.HideTranslations,
                ct);
        }
        
        if (request.ToggleRevertTranslations)
        {
            await _userRepository.ToggleWordsTemplateModeAsync(
                replyData.UserId,
                WordsTemplateMode.RevertWordAndTranslation,
                ct);
        }

        if (request.ShowMode is not null)
        {
            await _userRepository.SetShowWordsModeAsync(
                replyData.UserId,
                request.ShowMode.GetValueOrDefault(),
                ct);
        }
        
        if (request.LearnState is not null && request.OpenedWordTranslationId is not null)
        {
            await _wordsRepository.ChangeWordLearnStateAsync(
                replyData.UserId,
                request.OpenedWordTranslationId.GetValueOrDefault(),
                request.LearnState.GetValueOrDefault(),
                ct);
        }

        var userSettings = await _userRepository.GetSettingsAsync(replyData.UserId, ct);
        var result = await _wordsRepository.GetGroupWordsAsync(
            groupId,
            userSettings.ShowWordsMode,
            new PaginatedRequest(page, Constants.PaginationCount),
            ct);

        var closestGroups = await _wordsRepository
            .GetClosestUnlearnedGroupsAsync(groupId, ct);

        var idsForStatUpdate = result.Data.Select(x => x.TranslationId)
            .Except(userSettings.LastOpenedWordTranslationIds ?? Enumerable.Empty<long>())
            .ToArray();
        
        // Update view stat for the words 
        if (idsForStatUpdate.Length > 0)
        {
            await _statsRepository.IncrementSeenCountAsync(
                replyData.UserId,
                idsForStatUpdate,
                ct);

            result = result.MapTo(x => idsForStatUpdate.Contains(x.TranslationId)
                ? x with { ViewCount = x.ViewCount + 1 }
                : x);
        }

        var groupSerialNumber = await _wordsRepository.GetGroupSerialNumberAsync(groupId, ct);
        
        var shouldNumberBeSubtracted = groupSerialNumber % Constants.PaginationCount == 0;
        var pageNumber = groupSerialNumber / Constants.PaginationCount - (shouldNumberBeSubtracted ? 1 : 0);
        
        var returnBackButton = InlineKeyboardButton.WithCallbackData(
            "Return to the groups list 🔙",
            new RoutePathBuilder(TelegramRoutes.Groups)
                .WithQueryParameter(ParameterNames.Page, pageNumber));

        var areTranslationHidden = userSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.HideTranslations);
        
        var areTranslationsReverted = userSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.RevertWordAndTranslation);

        var groupRoute = new RoutePathBuilder(TelegramRoutes.Group)
            .WithQueryParameter(ParameterNames.GroupId, groupId)
            .WithQueryParameter(ParameterNames.Page, page);
        
        var toggleTranslationsButton = InlineKeyboardButton.WithCallbackData(
            areTranslationHidden
                ? "Show translations 👁"
                : "Hide translations 🙈",
            groupRoute.BuildFor(x => x
                .WithQueryParameter(ParameterNames.ToggleTranslations, true)));
        
        var reverseTranslationsButton = InlineKeyboardButton.WithCallbackData(
            areTranslationsReverted
                ? "W -> T"
                : "T -> W",
            groupRoute.BuildFor(x => x
                .WithQueryParameter(ParameterNames.RevertTranslations, true)));

        var changeShowWordsModeButtons = new List<InlineKeyboardButton>();
        if (userSettings.ShowWordsMode != ShowWordsMode.Hard)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: Hard 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.Hard))));
        }
        
        if (userSettings.ShowWordsMode != ShowWordsMode.NotLearned)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: Not Learned 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.NotLearned))));
        }
        
        if (userSettings.ShowWordsMode != ShowWordsMode.All)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: None 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.All))));
        }

        var routeBuilder = new RoutePathBuilder(TelegramRoutes.Group);

        var tmb = new TelegramMessageBuilder()
            .AppendRow(
                $"<b>Words of group {groupSerialNumber}. Page {page + 1}/{result.LastPage + 1}</b>")
            .AppendRow()
            .AppendDataRows(result, (x, i) =>
            {
                var msgBuilder = GetTextBuilder(x, areTranslationsReverted, areTranslationHidden);
                msgBuilder.Insert(0, ") ")
                    .Insert(0, x.SerialNumber);

                msgBuilder.Append($" (seen: {x.ViewCount}) ");
                
                if (x.LearnState.HasFlag(LearnState.Learned))
                {
                    msgBuilder.Append('✅');
                }

                if (x.LearnState.HasFlag(LearnState.Hard))
                {
                    msgBuilder.Append("🧠");
                }

                return msgBuilder.ToString();
            })
            .AppendRow("");

        var openedWord = result.Data
            .FirstOrDefault(x => x.TranslationId == request.OpenedWordTranslationId);

        if (openedWord is null)
        {
            tmb.AppendRow("Open word:");
        }
        else
        {
            tmb.AppendRow("Opened word:")
                .AppendRow(GetTextBuilder(openedWord, false, false).ToString());
        }

        tmb
            .AddInlineKeyboardButtons(result, (x, i) => InlineKeyboardButton.WithCallbackData(
                x.SerialNumber.ToString(),
                groupRoute.BuildFor(y => y
                    .WithQueryParameter(ParameterNames.OpenedWordId, x.TranslationId))));

        if (openedWord is not null)
        {
            var isLearned = openedWord.LearnState.HasFlag(LearnState.Learned);
            var switchLearnStateButton = InlineKeyboardButton.WithCallbackData(
                isLearned ? "Not learned ❌" : "Learned ✅",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(ParameterNames.LearnState, LearnState.Learned)
                    .WithQueryParameter(ParameterNames.OpenedWordId, openedWord.TranslationId)));
        
            var isHard = openedWord.LearnState.HasFlag(LearnState.Hard);
            var switchIsHardButton = InlineKeyboardButton.WithCallbackData(
                isHard ? "Easy " : "Hard 🧠",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(ParameterNames.LearnState, LearnState.Hard)
                    .WithQueryParameter(ParameterNames.OpenedWordId, openedWord.TranslationId)));

            tmb.AddInlineKeyboardButtons(new[] {switchLearnStateButton, switchIsHardButton});
        }

        InlineKeyboardButton? previousGroupButton = null;
        InlineKeyboardButton? nextGroupButton = null;
        
        if (closestGroups.PreviousGroupId is not null)
        {
            previousGroupButton = InlineKeyboardButton.WithCallbackData(
                "Previous group ⬅",
                routeBuilder.BuildFor(x => x.WithQueryParameter(
                    ParameterNames.GroupId, closestGroups.PreviousGroupId)));
        }
        
        if (!result.HasNextPage && closestGroups.NextGroupId is not null)
        {
            nextGroupButton = InlineKeyboardButton.WithCallbackData(
                "Next group ➡",
                routeBuilder.BuildFor(x => x.WithQueryParameter(
                    ParameterNames.GroupId, closestGroups.NextGroupId)));
        }

        tmb.AddPaginationButtons(
            result,
            routeBuilder.WithQueryParameter(ParameterNames.GroupId, groupId),
            fallbackButtons: new ControlButtons(previousGroupButton, nextGroupButton));
        
        tmb
            .AddInlineKeyboardButtons(new []{ toggleTranslationsButton, reverseTranslationsButton })
            .AddInlineKeyboardButtons(changeShowWordsModeButtons)
            .AddInlineKeyboardButtons(new []{ returnBackButton });

        await _client.EditMessageTextAsync(
            replyData,
            tmb,
            ParseMode.Html,
            cancellationToken: ct);

        await _userRepository.UpdateLastViewedTranslationsAsync(
            replyData.UserId,
            result.Data.Select(x => x.TranslationId).ToArray(),
            ct);
    }

    private static StringBuilder GetTextBuilder(
        LearningItem item,
        bool areTranslationsReverted,
        bool areTranslationHidden)
    {
        (string, string?) textParts = new ()
        {
            Item1 = areTranslationsReverted ? item.Translation : item.Word,
            Item2 = areTranslationHidden
                ? null
                : areTranslationsReverted
                    ? item.Word
                    : item.Translation
        };

        if (areTranslationHidden)
        {
            textParts.Item2 = null;
        }
            
        var msgBuilder = new StringBuilder()
            .Append(textParts.Item1);

        if (textParts.Item2 is not null)
        {
            msgBuilder.Append('-')
                .Append(textParts.Item2);
        }

        return msgBuilder;
    }
}