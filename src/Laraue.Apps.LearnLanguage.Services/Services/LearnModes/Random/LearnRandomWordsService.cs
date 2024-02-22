using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
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
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    DatabaseContext context,
    ISelectLanguageService selectLanguageService)
    : ILearnRandomWordsService
{
    public async Task SendRepeatingWindowAsync(
        WithSelectedTranslationRequest request,
        ReplyData replyData,
        CancellationToken ct = default)
    {
        var state = await repository.GetRepeatSessionStateAsync(replyData.UserId, ct);
        if (state is null)
        {
            await selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
                request,
                RandomMode.Title,
                TelegramRoutes.RepeatWindow,
                replyData,
                StartNewSessionAsync,
                ct);
        }
        else
        {
            await SendRepeatingWindowAsync(replyData, state.State, state.Id, ct);
        }
    }

    private async Task StartNewSessionAsync(
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var sessionId = await repository.CreateSessionAsync(replyData.UserId, selectedTranslation, ct);
        await SendRepeatingWindowAsync(replyData, RepeatState.Filling, sessionId, ct);
    }

    public async Task HandleSuggestedWordAsync(ReplyData replyData, HandleWordRequest request, CancellationToken ct = default)
    {
        // User pressed yes or no in suggested words window
        if (request.IsRemembered.HasValue)
        {
            // After the word has been added, session may be started
            var repeatState = await repository.AddWordToSessionAsync(
                request.SessionId, request.TranslationId, request.IsRemembered.Value, ct);

            // Send the repeat mode window in the current mode state
            await SendRepeatingWindowAsync(replyData, repeatState, request.SessionId, ct);
        }
        // User pressed show translation in suggested words window
        else if (request.ShowTranslation ?? false)
        {
            await SendWordWithTranslationAsync(
                replyData, request.TranslationId, request.SessionId, ct);
        }
    }

    private async Task SendRepeatingWindowAsync(ReplyData replyData, RepeatState state, long sessionId, CancellationToken ct = default)
    {
        if (state == RepeatState.Filling)
        {
            if (await TrySuggestWordAsync(replyData, sessionId, ct))
            {
                return;
            }
            
            await repository.ActivateSessionAsync(sessionId, ct);
            state = RepeatState.Active;
        }

        if (state == RepeatState.Active)
        {
            await HandleRepeatingWindowWordsViewAsync(
                replyData,
                new DetailView { SessionId = sessionId },
                ct);
        }
    }

    private async Task<bool> TrySuggestWordAsync(ReplyData replyData, long sessionId, CancellationToken ct = default)
    {
        var word = await repository.GetNextRepeatWordAsync(sessionId, NextWordPreference.Random, ct);

        if (word is null)
        {
            return false;
        }
        
        await wordsRepository.IncrementLearnAttemptsIfRequiredAsync(replyData.UserId, [word.Id], ct);
        await SendSuggestedWordAsync(word, replyData, sessionId, false, ct);

        return true;
    }
    
    public async Task HandleRepeatingWindowWordsViewAsync(
        ReplyData replyData,
        DetailView request,
        CancellationToken ct = default)
    {
        await userRepository.UpdateViewSettings(replyData.UserId, request, ct);
        
        await using var transaction = await context.Database.BeginTransactionAsync(ct);

        if (request is { OpenedWordTranslationId: not null })
        {
            await wordsRepository.ChangeWordLearnStateAsync(
                replyData.UserId,
                request.OpenedWordTranslationId.Value,
                request.IsLearned,
                request.IsMarked,
                ct);
            
            if (request is { IsLearned: true })
            {
                await repository.LearnWordAsync(
                    request.SessionId,
                    request.OpenedWordTranslationId.GetValueOrDefault(),
                    ct);
            }
        }

        if (await repository.TryFinishCurrentUserSessionAsync(replyData.UserId, ct))
        {
            await SendFinishSessionWindowAsync(replyData, request.SessionId, ct);
            await transaction.CommitAsync(ct);
            return;
        }
        
        var words = await repository.GetUnlearnedSessionWordsAsync(
            request.SessionId,
            new PaginatedRequest(request.Page, Constants.PaginationCount),
            ct);
        
        var userSettings = await userRepository.GetViewSettingsAsync(replyData.UserId, ct);
        var currentRoute = new CallbackRoutePath(TelegramRoutes.RepeatWindowWordsView)
            .WithQueryParameter(ParameterNames.SessionId, request.SessionId)
            .WithQueryParameter(ParameterNames.Page, request.Page)
            .Freeze();
        
        var wordsWindow = wordsWindowFactory
            .Create(
                words: words,
                userViewSettings: userSettings,
                viewRoute: currentRoute)
            .SetWindowTitle(RandomMode.Title)
            .SetBackButton(MessageBuilderExtensions.MainMenuButton);
        
        if (words.TryGetOpenedWord(request.OpenedWordTranslationId, out var openedWord))
        {
            wordsWindow.SetOpenedTranslation(openedWord);
            var switchLearnStateButton = currentRoute
                .WithQueryParameter(ParameterNames.LearnState, true)
                .WithQueryParameter(ParameterNames.OpenedTranslationId, openedWord.TranslationId)
                .ToInlineKeyboardButton(openedWord.LearnedAt is null ? "Learned ✅" : "Remembered");

            wordsWindow.SetActionButtons(new[] { switchLearnStateButton });
        }

        await wordsWindow.SendAsync(replyData, ct);
        await transaction.CommitAsync(ct);
    }

    private async Task SendFinishSessionWindowAsync(
        TelegramMessageId replyData,
        long sessionId,
        CancellationToken ct = default)
    {
        var info = await repository.GetSessionInfoAsync(sessionId, ct);

        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{RandomMode.SessionFinished}</b>")
            .AppendRow()
            .AppendRow(string.Format(RandomMode.WordsRemembered, $"<b>{info.WordsAddedToRepeatCount}</b>") )
            .AppendRow()
            .AppendRow(string
                .Format(
                    RandomMode.TimeSpent,
                    (info.FinishedAt - info.StartedAt).GetValueOrDefault().ToReadableString()));

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(RandomMode.Continue, TelegramRoutes.RepeatWindow),
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
        
        var handleRoute = new CallbackRoutePath(TelegramRoutes.HandleSuggestion)
            .WithQueryParameter(nameof(HandleWordRequest.SessionId), sessionId)
            .WithQueryParameter(nameof(HandleWordRequest.TranslationId), word.Id);
        
        handleRoute.Freeze();

        var requiredItemsCount = int.Min(session.MaxWordsInSessionCount, Constants.RepeatModeGroupSize);

        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{RandomMode.Title}</b>")
            .AppendRow()
            .AppendRow(string
                .Format(
                    RandomMode.CollectedWords,
                    $"<b>{session.WordsAddedToRepeatCount}/{requiredItemsCount}</b>"));

        if (session.WordsRememberedCount > 0)
        {
            tmb.AppendRow(
                string.Format(
                    RandomMode.RememberedWords,
                    $"<b>{session.WordsRememberedCount}/{sessionWordsCount}</b>"));
        }

        var doYouKnowPhrase = word.LearnedAt is not null
            ? RandomMode.DoYouRememberWord
            : RandomMode.DoYouKnowWord;
        
        tmb.AppendRow()
            .Append(string.Format(doYouKnowPhrase, $"<b>{word.Name}"));
        
        var difficultyString = CommonStrings.GetDifficultyString(word.Difficulty, word.CefrLevel);
        if (difficultyString is not null)
        {
            tmb.Append($" ({difficultyString})");
        }

        tmb.AppendRow("</b>?");

        if (showTranslation)
        {
            tmb.AppendRow($"{word.Name} - {word.Translation}");
            if (word.Topics.Length != 0)
            {
                tmb
                    .AppendRow()
                    .AppendRow(string.Format(Mode.Topic, string.Join(", ", word.Topics)));
            }
        }
        else
        {
            var showTranslationsButton = handleRoute
                .WithQueryParameter(nameof(HandleWordRequest.ShowTranslation), true)
                .ToInlineKeyboardButton(Buttons.SeeTranslation);
        
            tmb.AddInlineKeyboardButtons(new[] { showTranslationsButton });
        }

        var yesButton = handleRoute
            .WithQueryParameter(nameof(HandleWordRequest.IsRemembered), true)
            .ToInlineKeyboardButton(RandomMode.Yes);
        
        var noButton = handleRoute
            .WithQueryParameter(nameof(HandleWordRequest.IsRemembered), false)
            .ToInlineKeyboardButton(RandomMode.No);
        
        tmb.AddInlineKeyboardButtons(new[] { yesButton, noButton });
        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }
}