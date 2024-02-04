using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IStatsService
{
    /// <summary>
    /// Send to users their daily learn statistics.
    /// </summary>
    Task SendDailyStatMessages(CancellationToken ct = default);

    /// <summary>
    /// Send learning stats for the user.
    /// </summary>
    Task SendStatsAsync(ReplyData replyData, CancellationToken ct = default);
    
    /// <summary>
    /// Send admin stats to the user.
    /// </summary>
    Task SendAdminStatsAsync(ChatId telegramId, CancellationToken ct = default);
}