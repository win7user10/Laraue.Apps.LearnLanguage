using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.CefrLevel;

public sealed class LearnByCefrLevelService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByCefrLevelRepository learnByCefrLevelRepository) : 
        BaseLearnByGroupService<long, DetailViewByCefrLevel>(
            userRepository,
            wordsRepository,
            wordsWindowFactory,
            client,
            learnByCefrLevelRepository),
        ILearnByCefrLevelService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByCefrLevel;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByCefrLevel;
    protected override string ModeName => GroupMode.CefrLevel_Title;
}