using Laraue.Apps.LearnLanguage.Services.Repositories;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.CefrLevel;

public sealed class LearnByCefrLevelService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByCefrLevelRepository learnByCefrLevelRepository) : 
        BaseLearnByGroupService<long, LearnByCefrLevelRequest>(
            userRepository,
            wordsRepository,
            wordsWindowFactory,
            client,
            learnByCefrLevelRepository),
        ILearnByCefrLevelService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByCefrLevel;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByCefrLevel;
    protected override string ModeName => "By CEFR Level";
}