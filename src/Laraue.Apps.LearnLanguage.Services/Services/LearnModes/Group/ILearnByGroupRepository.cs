using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

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
        CancellationToken ct = default);

    /// <summary>
    /// Returns all groups with user stats for each of them.
    /// </summary>
    Task<IList<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        long languageIdToLearn,
        long languageIdToLearnFrom,
        CancellationToken ct = default);

    /// <summary>
    /// Returns group name for the passed group identifier.
    /// </summary>
    Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
}