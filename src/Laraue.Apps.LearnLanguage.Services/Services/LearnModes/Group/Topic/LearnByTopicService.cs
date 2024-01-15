using Laraue.Apps.LearnLanguage.Services.Repositories;
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
    protected override string ModeName => "By Topic";
}