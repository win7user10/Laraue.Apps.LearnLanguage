using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IWordsRepository
{
    /// <summary>
    /// Returns identifiers of the previous and the next unlearned group
    /// for the passed word group. 
    /// </summary>
    Task<ClosestUnlearnedGroups> GetClosestUnlearnedGroupsAsync(long groupId, CancellationToken ct = default);

    /// <summary>
    /// Returns true when word groups for the user has been generated.
    /// </summary>
    Task<bool> AreGroupsCreatedAsync(Guid userId, CancellationToken ct = default);

    /// <summary>
    /// Returns serial number for the word group.
    /// </summary>
    Task<long> GetGroupSerialNumberAsync(long wordGroupId, CancellationToken ct = default);

    /// <summary>
    /// Returns paginated word groups for the user.
    /// </summary>
    Task<IFullPaginatedResult<Group>> GetGroupsAsync(
        Guid userId,
        PaginatedRequest request,
        CancellationToken ct = default);

    /// <summary>
    /// Returns paginated words of the word group.
    /// </summary>
    Task<IFullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        long groupId,
        ShowWordsMode filter,
        PaginatedRequest request,
        CancellationToken ct = default);

    /// <summary>
    /// Get requested word information.
    /// </summary>
    Task<Word> GetWordAsync(Guid userId, long serialNumber, CancellationToken ct = default);

    /// <summary>
    /// Update learn state of the translation.
    /// </summary>
    /// <returns></returns>
    Task ChangeWordLearnStateAsync(
        Guid userId,
        long wordTranslationId,
        LearnState flagToChange,
        CancellationToken ct = default);

    /// <summary>
    /// Generate word groups for the user.
    /// </summary>
    Task GenerateGroupsAsync(Guid userId, bool shuffleWords, CancellationToken ct = default);
}