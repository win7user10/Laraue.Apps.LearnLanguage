using Laraue.Apps.LearnLanguage.Services.Services;

namespace Laraue.Apps.LearnLanguage.Services.Jobs;

public class CalculateDailyStatJob
{
    private readonly IStatsService _statsService;

    public CalculateDailyStatJob(IStatsService statsService)
    {
        _statsService = statsService;
    }

    public Task ExecuteAsync()
    {
        return _statsService.SendDailyStatMessages();
    }
}