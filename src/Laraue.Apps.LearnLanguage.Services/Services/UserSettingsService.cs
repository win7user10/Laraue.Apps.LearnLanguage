using System.Globalization;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Apps.LearnLanguage.Services.Services.Contracts;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class UserSettingsService(IUserRepository repository, ITelegramBotClient client, IWordsRepository wordsRepository)
    : IUserSettingsService
{
    public async Task HandleSettingsViewAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var settings = await repository.GetSettingsAsync(replyData.UserId, ct);
        var interfaceLanguage = InterfaceLanguage.ForCode(settings.InterfaceLanguageCode); 
        
        var tmb = new TelegramMessageBuilder();

        tmb.AppendRow($"<b>{Settings.Title}</b>")
            .AppendRow()
            .AppendRow(string.Format(Settings.CurrentLanguage, $"<b>{interfaceLanguage.Title}</b>"))
            .AppendRow(string.Format(
                Settings.CurrentLearnLanguage,
                settings.LanguageToLearnCode is not null || settings.LanguageToLearnFromCode is not null
                    ? $"<b>{settings.LanguageToLearnFromCode} -> {settings.LanguageToLearnCode}</b>"
                    : $"<b>{Settings.NotSet}</b>"))
            .AppendRow()
            .AppendRow(Settings.Edit);

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_Language, TelegramRoutes.InterfaceLanguageSettings),
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_LearnLanguage, TelegramRoutes.LearnLanguageSettings)
        });

        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task HandleInterfaceLanguageSettingsViewAsync(
        ReplyData replyData,
        UpdateInterfaceLanguageSettingsRequest request,
        CancellationToken ct = default)
    {
        if (request.LanguageCode is not null)
        {
            await repository.SetLanguageCodeAsync(
                replyData.UserId,
                request.LanguageCode,
                ct);

            // Directly change culture to see changes immediately in the current request
            CultureInfo.CurrentCulture = new CultureInfo(request.LanguageCode);
            CultureInfo.CurrentUICulture = new CultureInfo(request.LanguageCode);
            
            await HandleSettingsViewAsync(replyData, ct);
            return;
        }
        
        var tmb = new TelegramMessageBuilder();
        var path = new CallbackRoutePath(TelegramRoutes.InterfaceLanguageSettings);

        tmb
            .AppendRow($"<b>{Settings.UpdateTitle}</b>")
            .AppendRow()
            .AppendRow(Settings.SelectLanguage);

        tmb.AddInlineKeyboardButtons(InterfaceLanguage.Available
            .Select(x => path
                .WithQueryParameter(nameof(UpdateInterfaceLanguageSettingsRequest.LanguageCode), x.Code)
                .ToInlineKeyboardButton(x.Title)));

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_BackButton, TelegramRoutes.Settings)
        });
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task HandleLearnLanguageSettingsViewAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var availableLanguagePairs = await wordsRepository.GetAvailableLearningPairsAsync(ct);
        var path = new CallbackRoutePath(TelegramRoutes.LearnLanguageSettings, RouteMethod.Post)
            .Freeze();
        
        var tmb = new TelegramMessageBuilder();
        
        tmb
            .AppendRow($"<b>{Settings.UpdateTitle}</b>")
            .AppendRow()
            .AppendRow(Settings.SelectLearnLanguage);
        
        tmb.AddInlineKeyboardButtons(availableLanguagePairs
            .Select(x => path
                .WithQueryParameter(ParameterNames.LanguageToLearnFrom, x.LanguageToLearnFrom.Id)
                .WithQueryParameter(ParameterNames.LanguageToLearn, x.LanguageToLearn.Id)
                .ToInlineKeyboardButton($"{x.LanguageToLearnFrom.Code} -> {x.LanguageToLearn.Code} ({x.Count})")));

        tmb.AddInlineKeyboardButtons(new[]
        {
            path.ToInlineKeyboardButton(Settings.NotSet)
        });
        
        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_BackButton, TelegramRoutes.Settings)
        });
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public Task UpdateLearnLanguageSettingsAsync(
        ReplyData replyData,
        UpdateLearnLanguageSettingsRequest request,
        CancellationToken ct = default)
    {
        return repository.UpdateLanguageSettingsAsync(
            replyData.UserId,
            new SelectedTranslation(request.LanguageToLearnId, request.LanguageToLearnFromId),
            ct);
    }
}