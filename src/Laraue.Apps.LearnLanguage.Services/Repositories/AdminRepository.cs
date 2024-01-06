using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB;
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

        var registeredUsers = await _context.Users
            .Where(x => x.CreatedAt >= weekBeforeDate)
            .GroupBy(x => x.CreatedAt.Date)
            .Select(x => new RegisteredUsers(x.Key, x.Count()))
            .ToListAsyncEF(ct);
        
        var totalUserCount = await _context.Users
            .CountAsyncEF(ct);
        
        var activeUsers = await _context.WordTranslationStates
            .Where(x => (x.LearnedAt.HasValue && x.LearnedAt.Value >= weekBeforeDate)
                || (x.RepeatedAt.HasValue && x.RepeatedAt.Value >= weekBeforeDate))
            .GroupBy(x => x.User.TelegramId)
            .Select(x => new ActiveUser(
                x.Key.GetValueOrDefault(),
                x.Count(y => y.LearnedAt >= weekBeforeDate),
                x.Count(y => y.RepeatedAt >= weekBeforeDate)))
            .ToListAsyncEF(ct);

        return new AdminStats(
            totalUserCount,
            registeredUsers,
            activeUsers);
    }
}