using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IWordsService
{
    /// <summary>
    /// Send word groups to the user.
    /// </summary>
    Task SendWordGroupsAsync(ReplyData replyData, int page, CancellationToken ct = default);

    /// <summary>
    /// Send words of the group to the user.
    /// </summary>
    Task SendWordsAsync(
        ReplyData replyData,
        long groupId,
        int page,
        ChangeViewSettings request,
        CancellationToken ct = default);

    public record ChangeViewSettings
    {
        public bool ToggleShowTranslations { get; init; }
    
        public bool ToggleRevertTranslations { get; init; }
    
        public ShowWordsMode? ShowMode { get; init; }

        public long? OpenedWordTranslationId { get; init; }

        public LearnState? LearnState { get; init; }
    }
}