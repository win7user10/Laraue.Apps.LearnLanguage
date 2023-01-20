using Laraue.Apps.LearnLanguage.Common.Services;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Telegram.NET.Core.Utils;
using LinqToDB.EntityFrameworkCore;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Commands.Jobs;

public class CalculateDailyStatJob
{
    private readonly DatabaseContext _dbContext;
    private readonly ITelegramBotClient _telegramBotClient;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CalculateDailyStatJob(
        DatabaseContext dbContext,
        ITelegramBotClient telegramBotClient,
        IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _telegramBotClient = telegramBotClient;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public async Task ExecuteAsync()
    {
        var yesterdayDate = _dateTimeProvider.UtcNow.AddDays(-1).Date;
        
        var learnedStat = await _dbContext
            .Users
            .Where(x => x.WordGroups.SelectMany(y => y.WordGroupWordTranslations)
                .Any(y => y.LearnedAt.HasValue
                    && y.LearnedAt.Value.Date == yesterdayDate))
            .Select(x => new
            {
                x.TelegramId,
                Count = x.WordGroups.SelectMany(y => y.WordGroupWordTranslations)
                    .Count(y => y.LearnedAt.HasValue
                        && y.LearnedAt.Value.Date == yesterdayDate)
            })
            .ToListAsyncLinqToDB();

        foreach (var userLearnedStat in learnedStat)
        {
            var messageBuilder = new TelegramMessageBuilder()
                .AppendRow($"Today you have been learned {userLearnedStat.Count} words!")
                .AddDeleteMessageButton("Okay");
            
            await _telegramBotClient.SendTextMessageAsync(
                userLearnedStat.TelegramId!,
                messageBuilder.Text,
                replyMarkup: messageBuilder.InlineKeyboard);
        }
    }
}