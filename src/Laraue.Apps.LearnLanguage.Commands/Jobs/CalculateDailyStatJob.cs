using Laraue.Apps.LearnLanguage.DataAccess;
using LinqToDB.EntityFrameworkCore;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Commands.Jobs;

public class CalculateDailyStatJob
{
    private readonly DatabaseContext _dbContext;
    private readonly ITelegramBotClient _telegramBotClient;

    public CalculateDailyStatJob(DatabaseContext dbContext, ITelegramBotClient telegramBotClient)
    {
        _dbContext = dbContext;
        _telegramBotClient = telegramBotClient;
    }
    
    public async Task ExecuteAsync()
    {
        var learnedStat = await _dbContext
            .Users
            .Where(x => x.WordGroups.SelectMany(y => y.WordGroupWordTranslations)
                .Any(y => y.LearnedAt.HasValue
                    && y.LearnedAt.Value.Date == DateTime.UtcNow.Date))
            .Select(x => new
            {
                x.TelegramId,
                Count = x.WordGroups.SelectMany(y => y.WordGroupWordTranslations)
                    .Count(y => y.LearnedAt.HasValue
                        && y.LearnedAt.Value.Date == DateTime.UtcNow.Date)
            })
            .ToListAsyncLinqToDB();

        foreach (var userLearnedStat in learnedStat)
        {
            await _telegramBotClient.SendTextMessageAsync(
                userLearnedStat.TelegramId!,
                $"Today you have been learned {userLearnedStat.Count} words!");
        }
    }
}