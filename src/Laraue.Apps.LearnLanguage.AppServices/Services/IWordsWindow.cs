using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public interface IWordsWindow
{
    IWordsWindow SetWindowTitle(string title);
    IWordsWindow SetOpenedTranslation(LearningItem openedTranslation);
    IWordsWindow SetBackButton(InlineKeyboardButton button);
    Task SendAsync(ReplyData replyData, CancellationToken ct = default);
}