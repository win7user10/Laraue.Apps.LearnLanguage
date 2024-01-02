using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Extensions;
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
        var yesterdayDate = _dateTimeProvider.UtcNow.AddDays(-1);

        var registeredUsersCount = await _context.Users
            .Where(x => x.CreatedAt >= yesterdayDate)
            .CountAsyncEF(ct);
        
        var totalUserCount = await _context.Users
            .CountAsyncEF(ct);

        var learnedCount = await _context.WordTranslationStates
            .Where(x => x.LearnedAt.HasValue && x.LearnedAt.Value >= yesterdayDate)
            .CountAsyncEF(ct);

        var activeUsers = await _context.WordTranslationStates
            .Where(x => x.LearnedAt.HasValue && x.LearnedAt.Value >= yesterdayDate)
            .GroupBy(x => x.User.UserName)
            .Select(x => new ActiveUser(x.Key!, x.Count()))
            .ToListAsyncEF(ct);

        return new AdminStats(
            totalUserCount,
            registeredUsersCount,
            learnedCount,
            activeUsers);
    }
}