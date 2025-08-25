using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public class SelectLanguageService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    ITelegramBotClient client)
    : ISelectLanguageService
{
    public async Task ShowLanguageWindowOrHandleRequestAsync(
        WithSelectedTranslationRequest request,
        string languageWindowTitle,
        string nextRoute,
        ReplyData replyData,
        Func<ReplyData, SelectedTranslation, CancellationToken, Task> handleRequestAsync,
        CancellationToken ct = default)
    {
        var language = await TryGetSelectedLanguageAsync(replyData.UserId, request, ct);
        if (language is null)
        {
            await SendRequestLanguageWindowAsync(
                languageWindowTitle,
                replyData,
                new CallbackRoutePath(nextRoute),
                ct);
        }
        else
        {
            await handleRequestAsync(replyData, language, ct);
        }
    }
    
    private async Task<SelectedTranslation?> TryGetSelectedLanguageAsync(
        Guid userId,
        WithSelectedTranslationRequest selectedTranslation,
        CancellationToken ct = default)
    {
        if (selectedTranslation.LanguageToLearnId is not null || selectedTranslation.LanguageToLearnFromId is not null)
        {
            return new SelectedTranslation(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId);
        }
        
        var settings = await userRepository.GetSettingsAsync(userId, ct);

        return settings.LanguageToLearnFromId is not null || settings.LanguageToLearnId is not null
            ? new SelectedTranslation(settings.LanguageToLearnId, settings.LanguageToLearnFromId)
            : null;
    }

    private async Task SendRequestLanguageWindowAsync(
        string windowTitle,
        TelegramMessageId replyData,
        CallbackRoutePath nextRoute,
        CancellationToken ct = default)
    {
        var availablePairs = await wordsRepository.GetAvailableLearningPairsAsync(ct);
        
        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{windowTitle}</b>")
            .AppendRow()
            .AppendRow(Mode.SelectLanguage);

        foreach (var pair in availablePairs)
        {
            var button = nextRoute
                .WithTranslationDirection(
                    new SelectedTranslation(
                        pair.LanguageToLearn.Id,
                        pair.LanguageToLearnFrom.Id))
                .ToInlineKeyboardButton($"{pair.LanguageToLearnFrom.Code} -> {pair.LanguageToLearn.Code} ({pair.Count})");
            
            tmb.AddInlineKeyboardButtons([button]);
        }

        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }
}