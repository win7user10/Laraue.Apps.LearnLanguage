using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.Topic;

public sealed class LearnByTopicService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByTopicRepository learnByTopicRepository) : 
        BaseLearnByGroupService<long, LearnByTopicRequest>(
            userRepository,
            wordsRepository,
            wordsWindowFactory,
            client,
            learnByTopicRepository),
        ILearnByTopicService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByTopic;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByTopic;
    protected override string ModeName => GroupMode.Topics_Title;
}