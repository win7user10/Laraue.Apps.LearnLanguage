using Laraue.Apps.LearnLanguage.Services.Repositories;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;

public sealed class LearnByFirstLetterService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByFirstLetterRepository learnByFirstLetterRepository) : 
        BaseLearnByGroupService<char, LearnByFirstLetterRequest>(
            userRepository,
            wordsRepository,
            wordsWindowFactory,
            client,
            learnByFirstLetterRepository),
        ILearnByFirstLetterService
{
    protected override string ListRoute => TelegramRoutes.ListGroupsByFirstLetter;
    protected override string DetailRoute => TelegramRoutes.DetailGroupByFirstLetter;
    protected override string ModeName => "By first letter";
}