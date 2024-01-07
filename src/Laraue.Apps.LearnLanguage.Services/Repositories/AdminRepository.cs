using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

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
        var weekBeforeDate = _dateTimeProvider.UtcNow.AddDays(-7);

        var registeredUsers = (await _context.Users
            .Where(x => x.CreatedAt >= weekBeforeDate)
            .GroupBy(x => x.CreatedAt.Date)
            .OrderBy(x => x.Key)
            .Select(x => new RegisteredUsers(x.Key, x.Count()))
            .ToListAsyncEF(ct));
        
        var totalUserCount = await _context.Users
            .CountAsyncEF(ct);

        var activeUsersCount = await _context.WordTranslationStates
            .Where(x => (x.LearnedAt.HasValue && x.LearnedAt.Value >= weekBeforeDate)
                        || (x.RepeatedAt.HasValue && x.RepeatedAt.Value >= weekBeforeDate))
            .Select(x => x.UserId)
            .Distinct()
            .CountAsyncEF(ct);
        
        var activeUsers = await _context.WordTranslationStates
            .Where(x => (x.LearnedAt.HasValue && x.LearnedAt.Value >= weekBeforeDate)
                || (x.RepeatedAt.HasValue && x.RepeatedAt.Value >= weekBeforeDate))
            .Select(x => new
            {
                (x.RepeatedAt ?? x.LearnedAt)!.Value.Date,
                x.UserId
            })
            .Distinct()
            .GroupBy(x => x.Date)
            .OrderBy(x => x.Key)
            .Select(x => new ActiveUsers(
                x.Key,
                x.Count()))
            .ToListAsyncEF(ct);

        return new AdminStats(
            totalUserCount,
            activeUsersCount,
            registeredUsers,
            activeUsers);
    }
}