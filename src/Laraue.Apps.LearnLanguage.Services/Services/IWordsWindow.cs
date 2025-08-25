using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IWordsWindow
{
    IWordsWindow SetWindowTitle(string title);
    IWordsWindow SetOpenedTranslation(LearningItem openedTranslation);
    IWordsWindow SetBackButton(InlineKeyboardButton button);
    Task SendAsync(ReplyData replyData, CancellationToken ct = default);
}