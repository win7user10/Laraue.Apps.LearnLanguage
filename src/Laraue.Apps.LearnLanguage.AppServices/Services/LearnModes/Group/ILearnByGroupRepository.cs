using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Contracts.Enums;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group;

public interface ILearnByGroupRepository<TId>
    where TId : struct
{
    /// <summary>
    /// Returns paginated words of the passed group.
    /// </summary>
    Task<FullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        TId groupId,
        Guid userId,
        ShowWordsMode filter,
        IPaginationData request,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default);

    /// <summary>
    /// Returns all groups with user stats for each of them.
    /// </summary>
    Task<FullPaginatedResult<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginationData request,
        CancellationToken ct = default);

    /// <summary>
    /// Returns group name for the passed group identifier.
    /// </summary>
    Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
}