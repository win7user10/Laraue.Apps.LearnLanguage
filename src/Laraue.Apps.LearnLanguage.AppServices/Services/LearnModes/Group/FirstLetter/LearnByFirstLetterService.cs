using Laraue.Apps.LearnLanguage.AppServices.Repositories;
using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group.FirstLetter;

public sealed class LearnByFirstLetterService(
    IUserRepository userRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByFirstLetterRepository learnByFirstLetterRepository,
    ISelectLanguageService selectLanguageService) : 
        BaseLearnByGroupService<char, DetailViewByFirstLetterRequest>(
            userRepository,
            wordsWindowFactory,
            client,
            learnByFirstLetterRepository,
            selectLanguageService),
        ILearnByFirstLetterService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByFirstLetter;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByFirstLetter;
    protected override string ModeName => GroupMode.Sequential_Title;
}