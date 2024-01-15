using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public class LearnRandomWordsService(
    ILearnRandomWordsRepository repository,
    ITelegramBotClient client,
    IUserRepository userRepository,
    IWordsWindowFactory wordsWindowFactory)
    : ILearnRandomWordsService
{
    public async Task SendRepeatingWindowAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var state = await repository.GetRepeatSessionStateAsync(replyData.UserId, ct);
        if (state is null)
        {
            var sessionId = await repository.CreateSessionAsync(replyData.UserId, ct);
            state = new RepeatSessionState(sessionId, RepeatState.Filling);
        }

        await SendRepeatingWindowAsync(replyData, state.State, state.Id, ct);
    }

    public async Task HandleSuggestedWordAsync(ReplyData replyData, HandleWordRequest request, CancellationToken ct = default)
    {
        if (request.IsRemembered.HasValue)
        {
            var repeatState = await repository.AddWordToSessionAsync(
                request.SessionId, request.TranslationId, request.IsRemembered.Value, ct);

            await SendRepeatingWindowAsync(replyData, repeatState, request.SessionId, ct);
        }
        else if (request.ShowTranslation ?? false)
        {
            await SendWordWithTranslationAsync(
                replyData, request.TranslationId, request.SessionId, ct);
        }
    }

    private Task SendRepeatingWindowAsync(ReplyData replyData, RepeatState state, long sessionId, CancellationToken ct = default)
    {
        switch (state)
        {
            case RepeatState.Filling:
                return SendSuggestedWordAsync(replyData, sessionId, ct);
            case RepeatState.Active:
                return HandleRepeatingWindowWordsViewAsync(
                    replyData,
                    sessionId,
                    new ChangeUserSettings(),
                    default,
                    default,
                    default, 
                    ct);
        }

        return Task.CompletedTask;
    }

    private async Task SendSuggestedWordAsync(ReplyData replyData, long sessionId, CancellationToken ct = default)
    {
        var word = await repository.GetNextRepeatWordAsync(sessionId, NextWordPreference.Random, ct);
        await SendSuggestedWordAsync(word, replyData, sessionId, false, ct);
    }
    
    public async Task HandleRepeatingWindowWordsViewAsync(
        ReplyData replyData,
        long sessionId,
        ChangeUserSettings request,
        int page,
        long? openedTranslationId,
        bool rememberState,
        CancellationToken ct = default)
    {
        await userRepository.UpdateViewSettings(replyData.UserId, request, ct);
        if (rememberState && openedTranslationId is not null)
        {
            await repository.LearnWordAsync(
                sessionId,
                openedTranslationId.GetValueOrDefault(),
                ct);
        }
        
        var words = await repository.GetUnlearnedSessionWordsAsync(
            sessionId,
            new PaginatedRequest(page, Constants.PaginationCount),
            ct);
        
        if (words.Data.Count == 0)
        {
            await SendFinishSessionWindowAsync(replyData, sessionId, ct);
            return;
        }
        
        var userSettings = await userRepository.GetSettingsAsync(replyData.UserId, ct);
        var currentRoute = new RoutePathBuilder(TelegramRoutes.RepeatWindowWordsView)
            .WithQueryParameter(ParameterNames.SessionId, sessionId)
            .Freeze();
        
        var wordsWindow = wordsWindowFactory
            .Create(
                words: words,
                userSettings: userSettings,
                viewRoute: currentRoute)
            .SetWindowTitle("Repeat mode")
            .SetBackButton(MessageBuilderExtensions.MainMenuButton);
        
        if (words.TryGetOpenedWord(openedTranslationId, out var openedWord))
        {
            wordsWindow.SetOpenedTranslation(openedWord);
            var switchLearnStateButton = currentRoute
                .WithQueryParameter(ParameterNames.RememberState, true)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(openedWord.LearnedAt is null ? "Learned ✅" : "Remembered");

            wordsWindow.SetActionButtons(new[] { switchLearnStateButton });
        }

        await wordsWindow.SendAsync(replyData, ct);
    }

    private async Task SendFinishSessionWindowAsync(
        TelegramMessageId replyData,
        long sessionId,
        CancellationToken ct = default)
    {
        var info = await repository.GetSessionInfoAsync(sessionId, ct);

        var tmb = new TelegramMessageBuilder()
            .AppendRow("<b>Repeat session finished</b>")
            .AppendRow()
            .AppendRow($"<b>{info.WordsAddedToRepeatCount}</b> words remembered")
            .AppendRow()
            .AppendRow($"Time spent: {(info.FinishedAt - info.StartedAt).GetValueOrDefault().ToReadableString()}");

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData("Continue", TelegramRoutes.RepeatWindow),
        });
        
        await client.EditMessageTextAsync(replyData, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }

    private async Task SendWordWithTranslationAsync(
        ReplyData replyData,
        int translationId,
        long sessionId,
        CancellationToken ct = default)
    {
        var word = await repository.GetRepeatWordAsync(replyData.UserId, translationId, ct);
        await SendSuggestedWordAsync(word, replyData, sessionId, true, ct);
    }
    
    private async Task SendSuggestedWordAsync(
        NextRepeatWordTranslation word,
        TelegramMessageId replyData,
        long sessionId,
        bool showTranslation,
        CancellationToken ct = default)
    {
        var session = await repository.GetSessionInfoAsync(sessionId, ct);
        var sessionWordsCount = session.WordsAddedToRepeatCount + session.WordsRememberedCount;
        
        var handleRoute = new RoutePathBuilder(TelegramRoutes.HandleSuggestion)
            .WithQueryParameter(nameof(HandleWordRequest.SessionId), sessionId)
            .WithQueryParameter(nameof(HandleWordRequest.TranslationId), word.Id);
        
        handleRoute.Freeze();
        
        var tmb = new TelegramMessageBuilder()
            .AppendRow("<b>Random learning mode</>")
            .AppendRow()
            .AppendRow($"Collected <b>{session.WordsAddedToRepeatCount}/{Constants.RepeatModeGroupSize}</b>" +
                       $" new or forgotten words to learn");

        if (session.WordsRememberedCount > 0)
        {
            tmb.AppendRow($"Remembered words - <b>{session.WordsRememberedCount}/{sessionWordsCount}</b>");
        }
        
        tmb.AppendRow()
            .Append(word.LearnedAt is not null
                ? $"Do your steel remember the word"
                : $"Do your know the word");

        tmb.Append($" <b>{word.Name}");
        
        var difficultyString = CommonStrings.GetDifficultyString(word.Difficulty, word.CefrLevel);
        if (difficultyString is not null)
        {
            tmb.Append($" ({difficultyString})");
        }

        tmb.AppendRow("</b>?");

        if (showTranslation)
        {
            tmb.AppendRow($"{word.Name} - {word.Translation}");
            if (word.Topic is not null)
            {
                tmb
                    .AppendRow()
                    .AppendRow($"Topic: {word.Topic}");
            }
        }
        else
        {
            var showTranslationsButton = handleRoute
                .WithQueryParameter(nameof(HandleWordRequest.ShowTranslation), true)
                .ToInlineKeyboardButton("See translation 👁");
        
            tmb.AddInlineKeyboardButtons(new[] { showTranslationsButton });
        }

        var yesButton = handleRoute
            .WithQueryParameter(nameof(HandleWordRequest.IsRemembered), true)
            .ToInlineKeyboardButton("Yes");
        
        var noButton = handleRoute
            .WithQueryParameter(nameof(HandleWordRequest.IsRemembered), false)
            .ToInlineKeyboardButton("No");
        
        tmb.AddInlineKeyboardButtons(new[] { yesButton, noButton });
        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }
}