using Laraue.Apps.LearnLanguage.Commands.Queries;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record SendStartMessageCommand : BaseCommand<Message>;

public class SendStartMessageCommandHandler : IRequestHandler<SendStartMessageCommand, object?>
{
    private readonly ITelegramBotClient _client;
    private readonly IMediator _mediator;

    public SendStartMessageCommandHandler(ITelegramBotClient client, IMediator mediator)
    {
        _client = client;
        _mediator = mediator;
    }

    public async Task<object?> Handle(SendStartMessageCommand request, CancellationToken cancellationToken)
    {
        var currentState = await _mediator.Send(
            new GetCurrentStateQuery(request.UserId),
            cancellationToken);

        var chatId = request.Data.From!.Id;
        
        int? messageId = null;
        if (!currentState.AreGroupsFormed)
        {
            var message = await _client.SendTextMessageAsync(
                chatId,
                "We are preparing data for you. Please wait for a while",
                cancellationToken: cancellationToken);

            messageId = message.MessageId;
            
            await _mediator.Send(
                new GenerateGroupsCommand(request.UserId, false),
                cancellationToken);
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
                chatId,
                text,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }
        else
        {
            await _client.EditMessageTextAsync(
                chatId,
                messageId.Value,
                text,
                ParseMode.Html,
                replyMarkup: replyMarkup,
                cancellationToken: cancellationToken);
        }

        return null;
    }
}