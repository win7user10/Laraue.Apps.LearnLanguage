using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IAdminRepository
{
    Task<AdminStats> GetStatsAsync(CancellationToken ct = default);
}