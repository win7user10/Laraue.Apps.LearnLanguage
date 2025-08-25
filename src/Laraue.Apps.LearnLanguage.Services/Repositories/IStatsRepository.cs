using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IStatsRepository
{
    /// <summary>
    /// Get learn total statistics for the user.
    /// </summary>
    Task<LearnStats> GetLearnStatsAsync(Guid userId, CancellationToken ct = default);
}