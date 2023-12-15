using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class StatsService : IStatsService
{
    private readonly IUserRepository _userRepository;
    private readonly IWordsRepository _wordsRepository;
    private readonly IStatsRepository _statsRepository;
    private readonly ITelegramBotClient _client;

    public StatsService(
        IUserRepository userRepository,
        ITelegramBotClient client,
        IWordsRepository wordsRepository,
        IStatsRepository statsRepository)
    {
        _userRepository = userRepository;
        _client = client;
        _wordsRepository = wordsRepository;
        _statsRepository = statsRepository;
    }

    public async Task SendDailyStatMessages(CancellationToken ct = default)
    {
        var learnedStat = await _statsRepository.GetYesterdayAllUsersStatsAsync(ct);

        foreach (var userLearnedStat in learnedStat)
        {
            var learnedYesterdayPercent = userLearnedStat.LearnedYesterdayCount
                .DivideAndReturnPercent(userLearnedStat.TotalWordsCount);
            
            var messageBuilder = new TelegramMessageBuilder()
                .AppendRow($"Yesterday you have been learned {userLearnedStat.LearnedYesterdayCount} words!")
                .AppendRow($"Total stat is {userLearnedStat.LearnedTotalCount} / {userLearnedStat.TotalWordsCount} (+{learnedYesterdayPercent:F}%)")
                .AddDeleteMessageButton("Okay");
            
            await _client.SendTextMessageAsync(
                userLearnedStat.TelegramId,
                messageBuilder,
                cancellationToken: ct);
        }
    }

    public async Task SendStatsAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var learnStats = await _statsRepository.GetLearnStatsAsync(replyData.UserId, ct);
        
        var totalStat = learnStats.TotalStat;
        var learnPercent = totalStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);

        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow("<b>Learn stat</b>")
            .AppendRow("")
            .AppendRow($"Total learned {totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)");
            
        var learnSpeed = totalStat.LearnSpeed is not null 
            ? $"{totalStat.LearnSpeed:F}"
            : "N/A";
        
        var finishLearnDate = totalStat.ApproximateLearnDate is not null
            ? $"{totalStat.ApproximateLearnDate.Value.ToShortDateString()}"
            : "N/A";

        tmb
            .AppendRow($"Learn speed: {learnSpeed} words/day")
            .AppendRow("")
            .AppendRow($"Approximate finish learning date: {finishLearnDate}")
            .AppendRow("")
            .AppendRow("Words learned in past 10 days");

        if (learnStats.DaysStat.Count == 0)
        {
            tmb.AppendRow("N/A");
        }
        
        foreach (var dayStat in learnStats.DaysStat)
        {
            var dayLearnPercent = dayStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
            tmb.AppendRow($"{dayStat.Date.ToShortDateString()} - {dayStat.LearnedCount} word(s) - {dayLearnPercent:F}%");
        }

        tmb.AddMainMenuButton();
    }

    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow("Please select the action")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData("Learn words", TelegramRoutes.Groups)
            })
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData("See stat", TelegramRoutes.Stat)
            });

        return _client.EditMessageTextAsync(replyData, tmb, cancellationToken: ct);
    }

    public async Task SendStartAsync(Guid userId, ChatId telegramId, CancellationToken ct = default)
    {
        var areGroupsCreated = await _wordsRepository
            .AreGroupsCreatedAsync(userId, ct);
        
        int? messageId = null;
        if (!areGroupsCreated)
        {
            var message = await _client.SendTextMessageAsync(
                telegramId,
                "We are preparing data for you. Please wait for a while",
                cancellationToken: ct);

            messageId = message.MessageId;

            await _wordsRepository.GenerateGroupsAsync(userId, false, ct);
        }

        const string text = "Welcome to learn english channel. To start learning words, please press the button below.";
        var replyMarkup = new InlineKeyboardMarkup(
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    "Start learning",
                    TelegramRoutes.Groups)
            });

        if (messageId is null)
        {
            await _client.SendTextMessageAsync(
                telegramId,
                text,
                replyMarkup: replyMarkup,
                cancellationToken: ct);
        }
        else
        {
            await _client.EditMessageTextAsync(
                telegramId,
                messageId.Value,
                text,
                ParseMode.Html,
                replyMarkup: replyMarkup,
                cancellationToken: ct);
        }
    }
}