using Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

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
    Task StartAsync(
        string rawCommand,
        Guid userId,
        long telegramId,
        CancellationToken ct = default);

    Task HandleApplyStartSettingsAsync(
        ApplyStartSettingsRequest request,
        ReplyData replyData,
        CancellationToken ct = default);
}