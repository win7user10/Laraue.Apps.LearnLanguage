using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface ISequentialModeService
{
    /// <summary>
    /// Send word groups to the user.
    /// </summary>
    Task SendGroupsViewAsync(ReplyData replyData, int page, CancellationToken ct = default);

    /// <summary>
    /// Send words of the group to the user.
    /// </summary>
    Task HandleSequentialWindowWordsViewAsync(
        ReplyData replyData,
        long groupId,
        int page,
        ChangeUserSettings request,
        long? openedWordTranslationId,
        LearnState? learnState,
        CancellationToken ct = default);
}