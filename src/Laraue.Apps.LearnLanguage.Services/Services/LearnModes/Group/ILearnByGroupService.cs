namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public interface ILearnByGroupService<TId, in TDetailRequest>
    where TDetailRequest : BaseDetailViewByGroup<TId>
    where TId : struct
{
    /// <summary>
    /// Send words of the group to the user.
    /// </summary>
    Task HandleDetailViewAsync(
        ReplyData replyData,
        TDetailRequest request,
        CancellationToken ct = default);

    /// <summary>
    /// Send all groups to the user.
    /// </summary>
    Task HandleListViewAsync(
        LearnList learnList,
        ReplyData replyData,
        CancellationToken ct = default);
}