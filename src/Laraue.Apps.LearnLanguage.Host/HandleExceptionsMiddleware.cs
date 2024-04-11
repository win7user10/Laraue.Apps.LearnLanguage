using Laraue.Telegram.NET.Abstractions;
using Telegram.Bot.Exceptions;

namespace Laraue.Apps.LearnLanguage.Host;

public class HandleExceptionsMiddleware(ILogger<HandleExceptionsMiddleware> logger)
    : ITelegramMiddleware
{
    public async Task InvokeAsync(Func<CancellationToken, Task> next, CancellationToken ct = default)
    {
        try
        {
            await next(ct);
        }
        catch (ApiRequestException e)
        {
            logger.LogError(e, "Tg request error");
        }
    }
}