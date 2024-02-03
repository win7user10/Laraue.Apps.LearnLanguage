using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Core.Routing;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class WordsWindowFactory(
    ITelegramBotClient client,
    IWordsRepository wordsRepository) : IWordsWindowFactory
{
    public IWordsWindow Create(IFullPaginatedResult<LearningItem> words, UserSettings userSettings, RoutePathBuilder viewRoute)
    {
        return new WordsWindow(words, userSettings, viewRoute, client, wordsRepository);
    }
}