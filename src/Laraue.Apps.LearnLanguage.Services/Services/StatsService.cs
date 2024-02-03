using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
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
                .AppendRow(string.Format(Stats.YesterdayWereLearned, userLearnedStat.LearnedYesterdayCount))
                .AppendRow(
                    string.Format(
                        Stats.TotalStatIs,
                        $"{userLearnedStat.LearnedTotalCount} / {userLearnedStat.TotalWordsCount} (+{learnedYesterdayPercent:F}%)"))
                .AddDeleteMessageButton(Buttons.Okay);

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
        tmb.AppendRow($"<b>{Stats.Title}</b>")
            .AppendRow()
            .AppendRow(string.Format(Stats.TotalLearned, $"{totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)"))
            .AppendRow()
            .AppendRow(Stats.LearnedByCefrLevel);

        foreach (var cefrLevelStat in totalStat.ByCefrLevel)
        {
            var learnCefrPercent = cefrLevelStat.LearnedCount.DivideAndReturnPercent(cefrLevelStat.TotalCount);
            tmb.AppendRow($"{cefrLevelStat.Level} - {cefrLevelStat.LearnedCount}/{cefrLevelStat.TotalCount} ({learnCefrPercent:F}%)");
        }

        tmb
            .AppendRow()
            .AppendRow(Stats.LastActivity);

        if (dayLearnStatsCollection.Count == 0)
        {
            tmb.AppendRow(Stats.NA);
        }
        
        foreach (var dayStat in dayLearnStatsCollection)
        {
            var dayLearnPercent = dayStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
            tmb.AppendRow(
                string.Format(
                    Stats.LastActivityRow,
                    dayStat.Date.ToShortDateString(),
                    dayStat.LearnedCount,
                    dayStat.RepeatedCount,
                    $"{dayLearnPercent:F}"));
        }

        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendAdminStatsAsync(ChatId telegramId, CancellationToken ct = default)
    {
        var stats = await adminRepository.GetStatsAsync(ct);
        
        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow($"<b>{Stats.AdminStats_Title}</b>");
        tmb.AppendRow();
        
        tmb.AppendRow($"<b>{string.Format(Stats.AdminStats_TotalUsers, stats.TotalUsersCount)}</b>");
        foreach (var registeredUsers in stats.RegisteredUsers)
        {
            tmb.AppendRow($"{registeredUsers.Date:d} (+{registeredUsers.Count})");
        }
        
        tmb.AppendRow();
        tmb.AppendRow($"<b>{string.Format(Stats.AdminStats_ActiveUsers, stats.ActiveUsersCount / (double)stats.ActiveUsers.Count)}</b>");
        foreach (var activeUsers in stats.ActiveUsers)
        {
            tmb.AppendRow($"{activeUsers.Date:d} - {activeUsers.Count}");
        }
        
        await client.SendTextMessageAsync(telegramId, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }

    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{RandomMode.ButtonName}</b> - {RandomMode.Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.CefrLevel_ButtonName}</b> - {GroupMode.CefrLevel_Description}")
            .AppendRow()
            .AppendRow($"<b>{Buttons.Mode_Sequential}</b> - {GroupMode.Sequential_Description}")
            .AppendRow()
            .AppendRow($"<b>{Buttons.Mode_Topic}</b> - {GroupMode.Topics_Description}")
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
                    Buttons.Mode_Topic, TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Mode_Sequential, TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Stat, TelegramRoutes.Stat)
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