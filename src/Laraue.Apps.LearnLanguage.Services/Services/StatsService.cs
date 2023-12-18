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
    private readonly IWordsRepository _wordsRepository;
    private readonly IStatsRepository _statsRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly ITelegramBotClient _client;

    public StatsService(
        ITelegramBotClient client,
        IWordsRepository wordsRepository,
        IStatsRepository statsRepository,
        IAdminRepository adminRepository)
    {
        _client = client;
        _wordsRepository = wordsRepository;
        _statsRepository = statsRepository;
        _adminRepository = adminRepository;
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
            .AppendRow()
            .AppendRow($"Total learned {totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)");
            
        var learnSpeed = totalStat.LearnSpeed is not null 
            ? $"{totalStat.LearnSpeed:F}"
            : "N/A";
        
        var finishLearnDate = totalStat.ApproximateLearnDate is not null
            ? $"{totalStat.ApproximateLearnDate.Value.ToShortDateString()}"
            : "N/A";

        tmb
            .AppendRow($"Learn speed: {learnSpeed} words/day")
            .AppendRow()
            .AppendRow($"Approximate finish learning date: {finishLearnDate}")
            .AppendRow()
            .AppendRow("Words learned in the past 10 days");

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

        await _client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task SendAdminStatsAsync(ChatId telegramId, CancellationToken ct = default)
    {
        var stats = await _adminRepository.GetStatsAsync(ct);
        
        var tmb = new TelegramMessageBuilder();
        tmb.AppendRow("<b>Admin stats for yesterday</b>");
        tmb.AppendRow();
        
        tmb.AppendRow($"Total learned words: <b>{stats.LearnedCount}</b>");
        tmb.AppendRow();
        
        tmb.AppendRow($"Total users: <b>{stats.TotalUsersCount} (+{stats.RegisteredUsersCount})</b>");
        tmb.AppendRow();

        tmb.AppendRow($"<b>Active users:</b>");
        foreach (var activeUser in stats.ActiveUsers)
        {
            tmb.AppendRow($"{activeUser.Id} - {activeUser.LearnedCount} learned");
        }
        
        await _client.SendTextMessageAsync(telegramId, tmb, parseMode: ParseMode.Html, cancellationToken: ct);
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