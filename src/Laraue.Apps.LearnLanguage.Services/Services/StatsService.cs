using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class StatsService(
    ITelegramBotClient client,
    IStatsRepository statsRepository,
    IAdminRepository adminRepository,
    ILogger<StatsService> logger) : IStatsService
{
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
        
        await client.SendTextMessageAsync(telegramId, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
    }
}