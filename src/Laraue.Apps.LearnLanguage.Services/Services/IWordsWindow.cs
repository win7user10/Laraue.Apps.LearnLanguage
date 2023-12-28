using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IWordsWindow
{
    IWordsWindow SetWindowTitle(string title);
    IWordsWindow SetOpenedTranslation(LearningItem openedTranslation);
    IWordsWindow SetPaginationRoute(RoutePathBuilder paginationRoute);
    IWordsWindow SetBackButton(InlineKeyboardButton button);
    IWordsWindow SetFallbackPaginationButtons(ControlButtons controlButtons);
    IWordsWindow SetActionButtons(IEnumerable<InlineKeyboardButton> actionButtons);
    IWordsWindow UseFilters(bool useFilters = true);
    Task SendAsync(ReplyData replyData, CancellationToken ct = default);
}