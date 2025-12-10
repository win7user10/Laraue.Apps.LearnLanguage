using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using Laraue.Telegram.NET.Core.Routing;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public class WordsWindowFactory(
    ITelegramBotClient client,
    IDateTimeProvider dateTimeProvider) : IWordsWindowFactory
{
    public IWordsWindow Create(
        IFullPaginatedResult<LearningItem> words,
        UserViewSettings userViewSettings,
        CallbackRoutePath viewRoute)
    {
        return new WordsWindow(
            words,
            userViewSettings,
            viewRoute,
            client,
            dateTimeProvider);
    }
}