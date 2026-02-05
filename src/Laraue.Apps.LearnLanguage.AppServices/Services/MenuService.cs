using Laraue.Apps.LearnLanguage.AppServices.Extensions;
using Laraue.Apps.LearnLanguage.AppServices.Options;
using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public class MenuService(
    ITelegramBotClient client,
    DatabaseContext databaseContext,
    IOptions<TelegramOptions> options)
    : IMenuService
{
    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{QuizMode.ButtonName}</b> - {QuizMode.Description}")
            .AppendRow()
            .AppendRow($"<b>{Mode.ListMode}</b> - {Mode.ListModeDescription}")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    QuizMode.ButtonName, TelegramRoutes.CurrentQuiz),
                InlineKeyboardButton.WithCallbackData(
                    Mode.ListMode, TelegramRoutes.ViewWordsListMenu),
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

    public Task SendWordsListsMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{GroupMode.CefrLevel_ButtonName}</b> - {GroupMode.CefrLevel_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Sequential_ButtonName}</b> - {GroupMode.Sequential_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Topics_ButtonName}</b> - {GroupMode.Topics_Description}")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.CefrLevel_ButtonName, TelegramRoutes.ListGroupsByCefrLevel),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Topics_ButtonName, TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Sequential_ButtonName, TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddMainMenuButton();

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task StartAsync(
        string rawCommand,
        Guid userId,
        ChatId telegramId,
        CancellationToken ct = default)
    {
        await ProcessUtmLabels(rawCommand, userId, ct);
        
        // Send welcome message
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Menu.Start)
            .AddMainMenuButton();

        await client.SendTextMessageAsync(
            telegramId,
            tmb,
            cancellationToken: ct);
    }

    private async Task ProcessUtmLabels(
        string rawCommand,
        Guid userId,
        CancellationToken ct = default)
    {
        var hasUtmLabels = await databaseContext.UtmLabels
            .Where(l => l.UserId == userId)
            .AnyAsync(ct);

        if (hasUtmLabels)
        {
            return;
        }
        
        // Determine utm labels of the user
        var routeRegex = RouteRegexCreator.ForRoute(TelegramRoutes.Start);
        var match = routeRegex.Match(rawCommand);
        if (match.Groups.Count < 2)
        {
            return;
        }
        
        var queryRaw = match.Groups[1].Value;
        var queryParts =  queryRaw.Split('_');
        var dbUtmLabels = queryParts
            .Select(part => part.Split('-'))
            .Select(part => new UtmLabel
            {
                Name = part[0].Trim(),
                Value = part.Length > 1 ? part[1].Trim() : string.Empty,
                UserId = userId,
            })
            .ToArray();
                
        databaseContext.UtmLabels.AddRange(dbUtmLabels);
        await databaseContext.SaveChangesAsync(ct);
        
        // Check utm labels to do the first user setup if required
        var utmLabelOptions = options.Value.UtmLabels;
        var settingsToApply = utmLabelOptions
            .Join(
                dbUtmLabels,
                settingsOption => (settingsOption.Name, settingsOption.Value),
                dbOption => (dbOption.Name, dbOption.Value),
                (settingsOption, _) => settingsOption.Settings)
            .ToArray();

        var languageToLearnId = settingsToApply
            .Select(s => s.LanguageToLearn)
            .FirstOrDefault(s => s != null);

        if (languageToLearnId != null)
        {
            await databaseContext.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.LanguageToLearnId, languageToLearnId), ct);
        }
    }
}