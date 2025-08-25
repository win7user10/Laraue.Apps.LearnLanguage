using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class StatsRepository : IStatsRepository
{
    private readonly DatabaseContext _context;

    public StatsRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<LearnStats> GetLearnStatsAsync(Guid userId, CancellationToken ct = default)
    {
        var wordsCount = await _context.Words.CountAsyncLinqToDB(ct);
        
        var learnedCount = await _context.LearnedTranslations
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt != null)
            .CountAsyncLinqToDB(ct);

        var statByCefrLevel = await _context.Translations
            .GroupBy(x => x.Word.CefrLevelId)
            .OrderBy(x => x.Key)
            .Select(x => new CefrLevelStat(
                _context.CefrLevels
                    .Where(y => y.Id == x.Key)
                    .Select(y => y.Name)
                    .FirstOrDefault() ?? "Undefined",
                _context.LearnedTranslations
                    .Count(y => y.UserId == userId && y.Word.CefrLevelId == x.Key),
                x.Count()))
            .ToListAsyncEF(ct);

        var totalStat = new TotalStat(learnedCount, wordsCount, statByCefrLevel);

        var daysStat = await _context.LearnedTranslations
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt != null)
            .GroupBy(x => x.LearnedAt!.Value.Date)
            .OrderByDescending(x => x.Key)
            .Select(x => new DayLearnStats(
                x.Key,
                x.Count(y => y.LearnedAt != null)))
            .Take(10)
            .ToListAsyncEF(ct);

        return new LearnStats(totalStat, daysStat);
    }
}