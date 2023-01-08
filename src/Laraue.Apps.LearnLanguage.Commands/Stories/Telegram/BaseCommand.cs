using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record BaseCommand<TData> : IRequest<object?>
{
    public string UserId { get; init; }

    public TData Data { get; init; }
}