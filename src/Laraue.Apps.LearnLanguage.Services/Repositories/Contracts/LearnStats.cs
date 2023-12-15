namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearnStats(TotalStat TotalStat, ICollection<DayLearnStats> DaysStat);

public record TotalStat(int LearnedCount, int TotalCount, double? LearnSpeed, DateOnly? ApproximateLearnDate);

public record DayLearnStats(DateTime Date, int LearnedCount);