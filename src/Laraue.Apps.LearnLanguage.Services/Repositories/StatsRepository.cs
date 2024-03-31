using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class StatsRepository : IStatsRepository
{
    private readonly DatabaseContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public StatsRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<LearnStats> GetLearnStatsAsync(Guid userId, CancellationToken ct = default)
    {
        var wordsCount = await _context.Words.CountAsyncLinqToDB(ct);
        
        var learnedCount = await _context.TranslationStates
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt != null)
            .CountAsyncLinqToDB(ct);

        var statByCefrLevel = await _context.Translations
            .GroupBy(x => x.Meaning.CefrLevelId)
            .OrderBy(x => x.Key)
            .Select(x => new CefrLevelStat(
                _context.CefrLevels
                    .Where(y => y.Id == x.Key)
                    .Select(y => y.Name)
                    .FirstOrDefault() ?? "Undefined",
                _context.TranslationStates
                    .Count(y => y.UserId == userId && y.Translation.Meaning.CefrLevelId == x.Key),
                x.Count()))
            .ToListAsyncEF(ct);

        var totalStat = new TotalStat(learnedCount, wordsCount, statByCefrLevel);

        var daysStat = await _context.TranslationStates
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt != null || x.RepeatedAt != null)
            .GroupBy(x => (x.RepeatedAt ?? x.LearnedAt)!.Value.Date)
            .OrderByDescending(x => x.Key)
            .Select(x => new DayLearnStats(
                x.Key,
                x.Count(y => y.LearnedAt != null),
                x.Count(y => y.RepeatedAt != null)))
            .Take(10)
            .ToListAsyncEF(ct);

        return new LearnStats(totalStat, daysStat);
    }

    public async Task<IList<UserDailyStats>> GetYesterdayAllUsersStatsAsync(CancellationToken ct = default)
    {
        var yesterdayDate = _dateTimeProvider.Yesterday();
        
        return await _context
            .Users
            .Where(x => x.WordTranslationStates
                .Any(y => y.LearnedAt.HasValue
                          && y.LearnedAt.Value.Date == yesterdayDate))
            .Select(x => new UserDailyStats
            (
                x.TelegramId!.Value,
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue
                                && y.LearnedAt.Value.Date == yesterdayDate),
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue),
                _context.Words.Count()
            ))
            .ToListAsyncEF(ct);
    }
}