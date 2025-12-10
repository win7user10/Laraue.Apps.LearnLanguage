using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories;

public interface IAdminRepository
{
    Task<AdminStats> GetStatsAsync(CancellationToken ct = default);
}