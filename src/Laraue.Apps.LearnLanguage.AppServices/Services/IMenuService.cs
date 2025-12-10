using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

/// <summary>
/// Handle main menu commands.
/// </summary>
public interface IMenuService
{
    /// <summary>
    /// Send bot menu to the user.
    /// </summary>
    Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default);
    
    Task SendWordsListsMenuAsync(ReplyData replyData, CancellationToken ct = default);

    /// <summary>
    /// Send start messages to the user.
    /// </summary>
    Task SendStartAsync(Guid userId, ChatId telegramId, CancellationToken ct = default);
}