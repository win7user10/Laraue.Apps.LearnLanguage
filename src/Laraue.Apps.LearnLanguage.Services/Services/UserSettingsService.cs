using System.Globalization;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Apps.LearnLanguage.Services.Services.Contracts;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class UserSettingsService(IUserRepository repository, ITelegramBotClient client)
    : IUserSettingsService
{
    public async Task HandleSettingsViewAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var settings = await repository.GetSettingsAsync(replyData.UserId, ct);
        var interfaceLanguage = InterfaceLanguage.ForCode(settings.LanguageCode); 
        
        var tmb = new TelegramMessageBuilder();

        tmb.AppendRow($"<b>{Settings.Title}</b>")
            .AppendRow()
            .AppendRow(string.Format(Settings.CurrentLanguage, $"<b>{interfaceLanguage.Title}</b>"))
            .AppendRow()
            .AppendRow(Settings.Edit);

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_Language, TelegramRoutes.LanguageSettings)
        });

        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task HandleLanguageSettingsViewAsync(
        ReplyData replyData,
        UpdateSettingsRequest request,
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
        var path = new RoutePathBuilder(TelegramRoutes.LanguageSettings);

        tmb
            .AppendRow($"<b>{Settings.UpdateTitle}</b>")
            .AppendRow()
            .AppendRow(Settings.SelectLanguage);

        tmb.AddInlineKeyboardButtons(InterfaceLanguage.Available
            .Select(x => path
                .WithQueryParameter(nameof(UpdateSettingsRequest.LanguageCode), x.Code)
                .ToInlineKeyboardButton(x.Title)));

        tmb.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(
                Buttons.Settings_BackButton, TelegramRoutes.Settings)
        });
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }
}