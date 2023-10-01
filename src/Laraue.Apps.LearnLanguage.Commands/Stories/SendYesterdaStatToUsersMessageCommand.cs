using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using MediatR;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public sealed record SendDailyStatMessageCommand : IRequest;

public class SendDailyStatMessageCommandHandler : IRequestHandler<SendDailyStatMessageCommand>
{
    private readonly IMediator _mediator;
    private readonly ITelegramBotClient _telegramBotClient;

    public SendDailyStatMessageCommandHandler(
        IMediator mediator,
        ITelegramBotClient telegramBotClient)
    {
        _mediator = mediator;
        _telegramBotClient = telegramBotClient;
    }

    public async Task Handle(SendDailyStatMessageCommand request, CancellationToken cancellationToken)
    {
        var learnedStat = await _mediator.Send(
            new GetYesterdayUsersLearnStateQuery(),
            cancellationToken);

        foreach (var userLearnedStat in learnedStat)
        {
            var learnedYesterdayPercent = userLearnedStat.LearnedYesterdayCount
                .DivideAndReturnPercent(userLearnedStat.TotalWordsCount);
            
            var messageBuilder = new TelegramMessageBuilder()
                .AppendRow($"Yesterday you have been learned {userLearnedStat.LearnedYesterdayCount} words!")
                .AppendRow($"Total stat is {userLearnedStat.LearnedTotalCount} / {userLearnedStat.TotalWordsCount} (+{learnedYesterdayPercent:F}%)")
                .AddDeleteMessageButton("Okay");
            
            await _telegramBotClient.SendTextMessageAsync(
                userLearnedStat.TelegramId!,
                messageBuilder.Text,
                replyMarkup: messageBuilder.InlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}