using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class StatsService(
    ITelegramBotClient client,
    IStatsRepository statsRepository,
    IAdminRepository adminRepository,
    ILogger<StatsService> logger) : IStatsService
{
    public async Task SendDailyStatMessages(CancellationToken ct = default)
    {
        var learnedStat = await statsRepository.GetYesterdayAllUsersStatsAsync(ct);

        foreach (var userLearnedStat in learnedStat)
        {
            var learnedYesterdayPercent = userLearnedStat.LearnedYesterdayCount
                .DivideAndReturnPercent(userLearnedStat.TotalWordsCount);
            
            var messageBuilder = new TelegramMessageBuilder()
                .AppendRow($"Yesterday you have been learned {userLearnedStat.LearnedYesterdayCount} words!")
                .AppendRow($"Total stat is {userLearnedStat.LearnedTotalCount} / {userLearnedStat.TotalWordsCount} (+{learnedYesterdayPercent:F}%)")
                .AddDeleteMessageButton("Okay");

            try
            {
                await client.SendTextMessageAsync(
                    userLearnedStat.TelegramId,
                    messageBuilder,
                    cancellationToken: ct);
            }
            catch (Exception e)
            {
                logger.LogWarning(
                    e,
                    "Error while sending stat to the user {TelegramId}",
                    userLearnedStat.TelegramId);
            }
        }
    }

    public async Task SendStatsAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var (totalStat, dayLearnStatsCollection) = await statsRepository.GetLearnStatsAsync(replyData.UserId, ct);

        var learnPercent = totalStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);

        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow("<b>Learn stat</b>")
            .AppendRow()
            .AppendRow($"Total learned {totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)")
            .AppendRow()
            .AppendRow("Learned by CEFR level:");

        foreach (var cefrLevelStat in totalStat.ByCefrLevel)
        {
            var learnCefrPercent = cefrLevelStat.LearnedCount.DivideAndReturnPercent(cefrLevelStat.TotalCount);
            tmb.AppendRow($"{cefrLevelStat.Level} - {cefrLevelStat.LearnedCount}/{cefrLevelStat.TotalCount} ({learnCefrPercent:F}%)");
        }

        tmb
            .AppendRow()
            .AppendRow("Last activity:");

        if (dayLearnStatsCollection.Count == 0)
        {
            tmb.AppendRow("N/A");
        }
        
        foreach (var dayStat in dayLearnStatsCollection)
        {
            var dayLearnPercent = dayStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
            tmb.Append($"{dayStat.Date.ToShortDateString()} - learned: {dayStat.LearnedCount}")
                .AppendRow($", repeated: {dayStat.RepeatedCount} word(s) - {dayLearnPercent:F}%");
        }

        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendAdminStatsAsync(ChatId telegramId, CancellationToken ct = default)
    {
        var stats = await adminRepository.GetStatsAsync(ct);
        
        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow("<b>Admin stats for the last 7 days</b>");
        tmb.AppendRow();
        
        tmb.AppendRow($"<b>Total users: {stats.TotalUsersCount}</b>");
        foreach (var registeredUsers in stats.RegisteredUsers)
        {
            tmb.AppendRow($"{registeredUsers.Date:d} (+{registeredUsers.Count})");
        }
        
        tmb.AppendRow();
        tmb.AppendRow($"<b>Active users: {stats.ActiveUsersCount / (double)stats.ActiveUsers.Count:F} per day</b>");
        foreach (var activeUsers in stats.ActiveUsers)
        {
            tmb.AppendRow($"{activeUsers.Date:d} - {activeUsers.Count} user(s)");
        }
        
        await client.SendTextMessageAsync(telegramId, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }

    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow("Please select the action")
            .AppendRow()
            .AppendRow("<b>Random learning</b> allows to learn words in random order")
            .AppendRow()
            .Append("<b>Learning by CEFR level</b> allows to learn words by Common European Framework")
            .AppendRow(" of Reference for Languages, e.g. A1, A2 etc.")
            .AppendRow()
            .AppendRow("<b>Sequential learning</b> allows to learn words alphabetically from A to Z")
            .AppendRow()
            .AppendRow("<b>Learning by topic</b> allows to learn words by the specified category: family, body etc.")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    "Random learning", TelegramRoutes.RepeatWindow),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    "By CEFR level", TelegramRoutes.ListGroupsByCefrLevel),
                InlineKeyboardButton.WithCallbackData(
                    "By topic", TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    "Sequential learning", TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    "See stat", TelegramRoutes.Stat)
            });

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendStartAsync(Guid userId, ChatId telegramId, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow("Welcome to learn english channel. To start learning words, please press the button below.")
            .AddMainMenuButton();

        await client.SendTextMessageAsync(
            telegramId,
            tmb,
            cancellationToken: ct);
    }
}