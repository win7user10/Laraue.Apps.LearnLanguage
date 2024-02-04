using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class MenuService(ITelegramBotClient client) : IMenuService
{
    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{RandomMode.ButtonName}</b> - {RandomMode.Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.CefrLevel_ButtonName}</b> - {GroupMode.CefrLevel_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Sequential_ButtonName}</b> - {GroupMode.Sequential_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Topics_ButtonName}</b> - {GroupMode.Topics_Description}")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    RandomMode.ButtonName, TelegramRoutes.RepeatWindow),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.CefrLevel_ButtonName, TelegramRoutes.ListGroupsByCefrLevel),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Topics_ButtonName, TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Sequential_ButtonName, TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Stat, TelegramRoutes.Stat)
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Settings, TelegramRoutes.Settings)
            });

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendStartAsync(Guid userId, ChatId telegramId, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Menu.Start)
            .AddMainMenuButton();

        await client.SendTextMessageAsync(
            telegramId,
            tmb,
            cancellationToken: ct);
    }
}