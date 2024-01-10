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
    ISequentialModeRepository sequentialModeRepository,
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
        var learnStats = await statsRepository.GetLearnStatsAsync(replyData.UserId, ct);
        
        var totalStat = learnStats.TotalStat;
        var learnPercent = totalStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);

        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow("<b>Learn stat</b>")
            .AppendRow()
            .AppendRow($"Total learned {totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)");
            
        var learnSpeed = totalStat.LearnSpeed is not null 
            ? $"{totalStat.LearnSpeed:F}"
            : "N/A";
        
        var finishLearnDate = totalStat.ApproximateLearnDate is not null
            ? $"{totalStat.ApproximateLearnDate.Value.ToShortDateString()}"
            : "N/A";

        tmb
            .AppendRow($"Learn speed: {learnSpeed} words/day")
            .AppendRow()
            .AppendRow($"Approximate finish learning date: {finishLearnDate}")
            .AppendRow()
            .AppendRow("Words learned in the past 10 days");

        if (learnStats.DaysStat.Count == 0)
        {
            tmb.AppendRow("N/A");
        }
        
        foreach (var dayStat in learnStats.DaysStat)
        {
            var dayLearnPercent = dayStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
            tmb.AppendRow($"{dayStat.Date.ToShortDateString()} - {dayStat.LearnedCount} word(s) - {dayLearnPercent:F}%");
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
            .AppendRow("<b>Sequential mode</b> allows to learn words alphabetically from A to Z")
            .AppendRow("<b>Random mode</b> allows to learn words in random order")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData("Sequential learning", TelegramRoutes.Groups),
                InlineKeyboardButton.WithCallbackData("Random learning", TelegramRoutes.RepeatWindow),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData("See stat", TelegramRoutes.Stat)
            });

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendStartAsync(Guid userId, ChatId telegramId, CancellationToken ct = default)
    {
        var areGroupsCreated = await sequentialModeRepository
            .AreGroupsCreatedAsync(userId, ct);
        
        int? messageId = null;
        if (!areGroupsCreated)
        {
            var message = await client.SendTextMessageAsync(
                telegramId,
                "We are preparing data for you. Please wait for a while",
                cancellationToken: ct);

            messageId = message.MessageId;

            await sequentialModeRepository.GenerateGroupsAsync(userId, false, ct);
        }

        var tmb = new TelegramMessageBuilder()
            .AppendRow("Welcome to learn english channel. To start learning words, please press the button below.")
            .AddMainMenuButton();

        if (messageId is null)
        {
            await client.SendTextMessageAsync(
                telegramId,
                tmb,
                cancellationToken: ct);
        }
        else
        {
            await client.EditMessageTextAsync(
                telegramId,
                messageId.Value,
                tmb,
                ParseMode.Html,
                cancellationToken: ct);
        }
    }
}