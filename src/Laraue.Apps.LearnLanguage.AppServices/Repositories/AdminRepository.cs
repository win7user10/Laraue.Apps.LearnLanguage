using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly DatabaseContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AdminRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<AdminStats> GetStatsAsync(CancellationToken ct = default)
    {
        var weekBeforeDate = _dateTimeProvider.UtcNow.AddDays(-6);

        var registeredUsers = (await _context.Users
            .Where(x => x.CreatedAt >= weekBeforeDate)
            .GroupBy(x => x.CreatedAt.Date)
            .OrderBy(x => x.Key)
            .Select(x => new RegisteredUsers(x.Key, x.Count()))
            .ToListAsyncEF(ct));
        
        var totalUserCount = await _context.Users
            .CountAsyncEF(ct);

        var activeUsersCount = await _context.UserQuizzes
            .Where(x => x.CreatedAt >= weekBeforeDate)
            .Select(x => x.UserId)
            .Distinct()
            .CountAsyncEF(ct);

        return new AdminStats(
            totalUserCount,
            activeUsersCount,
            registeredUsers);
    }
}