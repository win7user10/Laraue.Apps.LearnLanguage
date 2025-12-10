using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Core.Routing;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public interface IWordsWindowFactory
{
    IWordsWindow Create(
        IFullPaginatedResult<LearningItem> words,
        UserViewSettings userViewSettings,
        CallbackRoutePath viewRoute);
}