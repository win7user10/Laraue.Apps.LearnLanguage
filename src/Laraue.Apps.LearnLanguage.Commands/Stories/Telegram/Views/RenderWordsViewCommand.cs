using System.Text;
using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Laraue.Telegram.NET.MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;

public record RenderWordsViewCommand(
        IPaginatedResult<LearningItem> Data,
        UserSettings UserSettings,
        ClosestUnlearnedGroups ClosestUnlearnedGroups,
        long GroupId,
        long GroupSerialNumber,
        long ChatId,
        int MessageId,
        long? OpenedWordTranslationId,
        string CallbackQueryId)
    : BaseEditMessageCommand<IPaginatedResult<LearningItem>>(Data, ChatId, MessageId, CallbackQueryId)
{
    public static class ParameterNames
    {
        public const string OpenedWordId = "o";
        public const string ToggleTranslations = "t";
        public const string RevertTranslations = "r";
        public const string ShowMode = "m";
        public const string LearnState = "l";
        public const string GroupId = "g";
    }
}

public class RenderWordsViewCommandHandler : BaseEditMessageCommandHandler<RenderWordsViewCommand, IPaginatedResult<LearningItem>>
{
    public RenderWordsViewCommandHandler(ITelegramBotClient client) : base(client)
    {
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

    protected override void HandleInternal(RenderWordsViewCommand request, TelegramMessageBuilder telegramMessageBuilder)
    {
        var shouldNumberBeAdded = request.GroupSerialNumber % Constants.PaginationCount != 0;
        var pageNumber = request.GroupSerialNumber / Constants.PaginationCount + (shouldNumberBeAdded ? 1 : 0);
        
        var returnBackButton = InlineKeyboardButton.WithCallbackData(
            "Return to the groups list 🔙",
            new RoutePathBuilder(TelegramRoutes.Groups)
                .WithQueryParameter(ParameterNames.Page, pageNumber));

        var areTranslationHidden = request.UserSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.HideTranslations);
        
        var areTranslationsReverted = request.UserSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.RevertWordAndTranslation);

        var groupRoute = new RoutePathBuilder(TelegramRoutes.Group)
            .WithQueryParameter(RenderWordsViewCommand.ParameterNames.GroupId, request.GroupId)
            .WithQueryParameter(ParameterNames.Page, request.Data.Page);
        
        // TODO - add current route property
        var toggleTranslationsButton = InlineKeyboardButton.WithCallbackData(
            areTranslationHidden
                ? "Show translations 👁"
                : "Hide translations 🙈",
            groupRoute.BuildFor(x => x
                .WithQueryParameter(RenderWordsViewCommand.ParameterNames.ToggleTranslations, true)));
        
        var reverseTranslationsButton = InlineKeyboardButton.WithCallbackData(
            areTranslationsReverted
                ? "W -> T"
                : "T -> W",
            groupRoute.BuildFor(x => x
                .WithQueryParameter(RenderWordsViewCommand.ParameterNames.RevertTranslations, true)));

        var changeShowWordsModeButtons = new List<InlineKeyboardButton>();
        if (request.UserSettings.ShowWordsMode != ShowWordsMode.Hard)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: Hard 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.ShowMode, ShowWordsMode.Hard))));
        }
        
        if (request.UserSettings.ShowWordsMode != ShowWordsMode.NotLearned)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: Not Learned 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.ShowMode, ShowWordsMode.NotLearned))));
        }
        
        if (request.UserSettings.ShowWordsMode != ShowWordsMode.All)
        {
            changeShowWordsModeButtons.Add(InlineKeyboardButton.WithCallbackData(
                "Filter: None 🔍",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.ShowMode, ShowWordsMode.All))));
        }

        var routeBuilder = new RoutePathBuilder(TelegramRoutes.Group);

        telegramMessageBuilder
            .AppendRow(
                $"<b>Words of group {request.GroupSerialNumber}. Page {request.Data.Page}/{request.Data.LastPage}</b>")
            .AppendRow("")
            .AppendDataRows(request.Data, (x, i) =>
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

        var openedWord = request.Data
            .Data
            .FirstOrDefault(x => x.TranslationId == request.OpenedWordTranslationId);

        if (openedWord is null)
        {
            telegramMessageBuilder.AppendRow("Open word:");
        }
        else
        {
            telegramMessageBuilder.AppendRow("Opened word:")
                .AppendRow(GetTextBuilder(openedWord, false, false).ToString());
        }

        telegramMessageBuilder
            .AddInlineKeyboardButtons(request.Data, (x, i) => InlineKeyboardButton.WithCallbackData(
                x.SerialNumber.ToString(),
                groupRoute.BuildFor(y => y
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.OpenedWordId, x.TranslationId))));

        if (openedWord is not null)
        {
            var isLearned = openedWord.LearnState.HasFlag(LearnState.Learned);
            var switchLearnStateButton = InlineKeyboardButton.WithCallbackData(
                isLearned ? "Not learned ❌" : "Learned ✅",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.LearnState, LearnState.Learned)
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.OpenedWordId, openedWord.TranslationId)));
        
            var isHard = openedWord.LearnState.HasFlag(LearnState.Hard);
            var switchIsHardButton = InlineKeyboardButton.WithCallbackData(
                isHard ? "Easy " : "Hard 🧠",
                groupRoute.BuildFor(x => x
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.LearnState, LearnState.Hard)
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.OpenedWordId, openedWord.TranslationId)));

            telegramMessageBuilder.AddInlineKeyboardButtons(new[] {switchLearnStateButton, switchIsHardButton});
        }

        InlineKeyboardButton? previousGroupButton = null;
        InlineKeyboardButton? nextGroupButton = null;
        
        if (request.ClosestUnlearnedGroups.PreviousGroupId is not null)
        {
            previousGroupButton = InlineKeyboardButton.WithCallbackData(
                "Previous group ⬅",
                routeBuilder.BuildFor(x => x.WithQueryParameter(
                    RenderWordsViewCommand.ParameterNames.GroupId, request.ClosestUnlearnedGroups.PreviousGroupId)));
        }
        
        if (!request.Data.HasNextPage && request.ClosestUnlearnedGroups.NextGroupId is not null)
        {
            nextGroupButton = InlineKeyboardButton.WithCallbackData(
                "Next group ➡",
                routeBuilder.BuildFor(x => x.WithQueryParameter(
                    RenderWordsViewCommand.ParameterNames.GroupId, request.ClosestUnlearnedGroups.NextGroupId)));
        }

        telegramMessageBuilder
            .AddControlButtons(
                request.Data,
                routeBuilder.WithQueryParameter(RenderWordsViewCommand.ParameterNames.GroupId, request.GroupId),
                new ControlButtons(previousGroupButton, nextGroupButton));
        
        telegramMessageBuilder
            .AddInlineKeyboardButtons(new []{ toggleTranslationsButton, reverseTranslationsButton })
            .AddInlineKeyboardButtons(changeShowWordsModeButtons)
            .AddInlineKeyboardButtons(new []{ returnBackButton });
    }
}