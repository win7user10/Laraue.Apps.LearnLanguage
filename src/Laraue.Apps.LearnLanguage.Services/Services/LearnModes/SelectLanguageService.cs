using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
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
                new RoutePathBuilder(nextRoute),
                ct);
        }
        else
        {
            await handleRequestAsync(replyData, language.Value, ct);
        }
    }
    
    private async Task<SelectedTranslation?> TryGetSelectedLanguageAsync(
        Guid userId,
        WithSelectedTranslationRequest selectedTranslation,
        CancellationToken ct = default)
    {
        if (selectedTranslation.LanguageIdToLearn is not null && selectedTranslation.LanguageIdToLearnFrom is not null)
        {
            return new SelectedTranslation(
                selectedTranslation.LanguageIdToLearn,
                selectedTranslation.LanguageIdToLearnFrom);
        }
        
        var settings = await userRepository.GetLanguageSettingsAsync(userId, ct);
        if (settings is not null)
        {
            return new SelectedTranslation(settings.LanguageIdToLearn, settings.LanguageIdToLearnFrom);
        }

        return null;
    }

    private async Task SendRequestLanguageWindowAsync(
        string windowTitle,
        TelegramMessageId replyData,
        RoutePathBuilder nextRoute,
        CancellationToken ct = default)
    {
        var availablePairs = await wordsRepository.GetAvailableLearningPairsAsync(ct);
        
        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{windowTitle}</b>")
            .AppendRow()
            .AppendRow($"Select the language pair to learn");

        tmb.AddInlineKeyboardButtons(availablePairs
            .Select(p => nextRoute
                .AddTranslationParameters(
                    new SelectedTranslation(
                        p.LanguageToLearn.Id,
                        p.LanguageToLearnFrom.Id))
                .ToInlineKeyboardButton($"{p.LanguageToLearnFrom.Code} -> {p.LanguageToLearn.Code} ({p.Count})")));

        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }
}