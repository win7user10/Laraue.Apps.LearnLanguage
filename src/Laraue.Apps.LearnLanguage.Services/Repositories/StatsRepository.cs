using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        var getUserWordsQuery = _context.WordGroupWords
            .Where(x => x.WordGroup.UserId == userId)
            .QueryGroupWordsWithStates(_context, (word, state) => new
            {
                state.LearnState,
                state.LearnedAt,
            });
        
        var wordsCount = await getUserWordsQuery.CountAsyncLinqToDB(ct);
        
        var learnedCount = await getUserWordsQuery
            .Where(x => (x.LearnState & LearnState.Learned) != 0)
            .CountAsyncLinqToDB(ct);

        var firstLearnedAt = await getUserWordsQuery
            .OrderBy(x => x.LearnedAt)
            .Select(x => x.LearnedAt)
            .FirstAsyncLinqToDB(ct);

        double? learnSpeed = null;
        DateOnly? approximateLearnWordsDate = null;
        if (firstLearnedAt is not null)
        {
            var learnDays = (DateTimeOffset.UtcNow - firstLearnedAt).Value.TotalDays;
            learnSpeed = learnedCount / learnDays;

            var daysToLearn = (int)Math.Ceiling((wordsCount - learnedCount) / learnSpeed.Value);
            approximateLearnWordsDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(daysToLearn));
        }

        var totalStat = new TotalStat(learnedCount, wordsCount, learnSpeed, approximateLearnWordsDate);

        var daysStat = await getUserWordsQuery
            .Where(x => x.LearnedAt != null)
            .GroupBy(x => x.LearnedAt!.Value.Date)
            .OrderByDescending(x => x.Key)
            .Select(x => new DayLearnStats(x.Key, x.Count()))
            .Take(10)
            .ToListAsyncLinqToDB(ct);

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
                x.WordGroups.Sum(y => y.WordGroupWords.Count)
            ))
            .ToListAsync(ct);
    }
}