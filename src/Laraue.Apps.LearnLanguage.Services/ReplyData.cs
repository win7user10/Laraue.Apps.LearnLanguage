using Laraue.Telegram.NET.Core.Extensions;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Services;

public record ReplyData(Guid UserId, ChatId TelegramId, int MessageId)
    : TelegramMessageId(TelegramId, MessageId)
{
    public static ReplyData FromRequest(RequestContext request)
    {
        return new ReplyData(
            request.UserId,
            request.Update.GetUserId(),
            request.Update.CallbackQuery.GetMessageId());
    }
}