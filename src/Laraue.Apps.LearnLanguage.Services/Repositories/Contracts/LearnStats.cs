namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearnStats(
    TotalStat TotalStat,
    ICollection<DayLearnStats> DaysStat);

public record TotalStat(int LearnedCount, int TotalCount, ICollection<CefrLevelStat> ByCefrLevel);

public record CefrLevelStat(string? Level, int LearnedCount, int TotalCount);

public record DayLearnStats(DateTime Date, int LearnedCount, int RepeatedCount);