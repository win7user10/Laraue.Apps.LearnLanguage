using Laraue.Apps.LearnLanguage.AppServices.Repositories;
using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group.Topic;

public sealed class LearnByTopicService(
    IUserRepository userRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByTopicRepository learnByTopicRepository,
    ISelectLanguageService selectLanguageService) : 
        BaseLearnByGroupService<long, DetailViewByTopicRequest>(
            userRepository,
            wordsWindowFactory,
            client,
            learnByTopicRepository,
            selectLanguageService),
        ILearnByTopicService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByTopic;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByTopic;
    protected override string ModeName => GroupMode.Topics_Title;
}