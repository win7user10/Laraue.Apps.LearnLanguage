using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories;

public interface IStatsRepository
{
    /// <summary>
    /// Get learn total statistics for the user.
    /// </summary>
    Task<LearnStats> GetLearnStatsAsync(Guid userId, CancellationToken ct = default);
}