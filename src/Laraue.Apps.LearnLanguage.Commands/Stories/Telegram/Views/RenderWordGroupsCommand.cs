using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Common.Extensions;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Laraue.Telegram.NET.MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;

public record RenderWordGroupsCommand(IPaginatedResult<GroupDto> Data, long ChatId, int MessageId, string CallbackQueryId)
    : BaseEditMessageCommand<IPaginatedResult<GroupDto>>(Data, ChatId, MessageId, CallbackQueryId);

public class RenderWordGroupsCommandHandler : BaseEditMessageCommandHandler<RenderWordGroupsCommand, IPaginatedResult<GroupDto>>
{
    public RenderWordGroupsCommandHandler(ITelegramBotClient client) : base(client)
    {
    }

    protected override void HandleInternal(RenderWordGroupsCommand request, TelegramMessageBuilder telegramMessageBuilder)
    {
        var learnedCount = request.Data.Data.Sum(x => x.LearnedCount);
        var totalCount = request.Data.Data.Sum(x => x.TotalCount);
        var completedPercent = learnedCount.DivideAndReturnPercent(totalCount);

        var groupRoute = new RoutePathBuilder(TelegramRoutes.Group);

        telegramMessageBuilder
            .AppendRow($"<b>Word groups. Page {request.Data.Page}/{request.Data.LastPage}.</b>")
            .AppendRow($"Learned words: {learnedCount}/{totalCount} ({completedPercent:F}%)")
            .AppendRow("")
            .AppendDataRows(request.Data, (x, _) => $"{x.SerialNumber}) {x.FirstWord}-* {x.LearnedCount}/{x.TotalCount}")
            .AppendRow("")
            .AppendRow("Open group: ")
            .AddInlineKeyboardButtons(request.Data, (x, i) => InlineKeyboardButton.WithCallbackData(
                x.SerialNumber.ToString(),
                groupRoute
                    .WithQueryParameter(RenderWordsViewCommand.ParameterNames.GroupId, x.SerialNumber)))
            .AddControlButtons(request.Data, new RoutePathBuilder(TelegramRoutes.Groups))
            .AddMainMenuButton();
    }
}