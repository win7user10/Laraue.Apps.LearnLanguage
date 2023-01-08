using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;

public record RenderStatViewCommand(GetLearnStateQueryResponse Data, long ChatId, int MessageId, string CallbackQueryId)
    : RenderViewCommand<GetLearnStateQueryResponse>(Data, ChatId, MessageId, CallbackQueryId);
    
public class RenderStatViewCommandCommandHandler : RenderViewCommandHandler<RenderStatViewCommand, GetLearnStateQueryResponse>
{
    public RenderStatViewCommandCommandHandler(ITelegramBotClient client) : base(client)
    {
    }

    protected override void HandleInternal(RenderStatViewCommand request, TelegramMessageBuilder telegramMessageBuilder)
    {
        var totalStat = request.Data.TotalStat;
        var learnPercent = totalStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
        telegramMessageBuilder.AppendRow("<b>Learn stat</b>")
            .AppendRow("")
            .AppendRow($"Total learned {totalStat.LearnedCount}/{totalStat.TotalCount} ({learnPercent:F}%)");
            
        var learnSpeed = totalStat.LearnSpeed is not null 
            ? $"{totalStat.LearnSpeed:F}"
            : "N/A";
        
        var finishLearnDate = totalStat.ApproximateLearnDate is not null
            ? $"{totalStat.ApproximateLearnDate.Value.ToShortDateString()}"
            : "N/A";

        telegramMessageBuilder
            .AppendRow($"Learn speed: {learnSpeed} words/day")
            .AppendRow("")
            .AppendRow($"Approximate finish learning date: {finishLearnDate}")
            .AppendRow("")
            .AppendRow("Words learned in past 10 days");

        if (request.Data.DaysStat.Count == 0)
        {
            telegramMessageBuilder.AppendRow("N/A");
        }
        
        foreach (var dayStat in request.Data.DaysStat)
        {
            var dayLearnPercent = dayStat.LearnedCount.DivideAndReturnPercent(totalStat.TotalCount);
            telegramMessageBuilder.AppendRow($"{dayStat.Date.ToShortDateString()} - {dayStat.LearnedCount} word(s) - {dayLearnPercent:F}%");
        }

        telegramMessageBuilder.AddMainMenuButton();
    }
}