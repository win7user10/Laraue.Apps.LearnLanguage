﻿using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;

public sealed class LearnByFirstLetterService(
    IUserRepository userRepository,
    IWordsRepository wordsRepository,
    IWordsWindowFactory wordsWindowFactory,
    ITelegramBotClient client,
    ILearnByFirstLetterRepository learnByFirstLetterRepository,
    ISelectLanguageService selectLanguageService) : 
        BaseLearnByGroupService<char, DetailViewByFirstLetterRequest>(
            userRepository,
            wordsRepository,
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