using Laraue.Telegram.NET.Abstractions;
using Telegram.Bot.Exceptions;

namespace Laraue.Apps.LearnLanguage.Host;

public class HandleExceptionsMiddleware(ITelegramMiddleware next, ILogger<HandleExceptionsMiddleware> logger)
    : ITelegramMiddleware
{
    public async Task InvokeAsync(CancellationToken ct = default)
    {
        try
        {
            await next.InvokeAsync(ct);
        }
        catch (ApiRequestException e)
        {
            logger.LogError(e, "Tg request error");
        }
    }
}