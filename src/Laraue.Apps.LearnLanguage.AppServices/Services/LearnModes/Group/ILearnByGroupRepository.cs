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
    Task<IFullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        TId groupId,
        Guid userId,
        ShowWordsMode filter,
        PaginatedRequest request,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default);

    /// <summary>
    /// Returns all groups with user stats for each of them.
    /// </summary>
    Task<IFullPaginatedResult<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginatedRequest request,
        CancellationToken ct = default);

    /// <summary>
    /// Returns group name for the passed group identifier.
    /// </summary>
    Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
}