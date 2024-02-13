﻿namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record LearningLanguagePair(LearningLanguagePairItem LanguageToLearn, LearningLanguagePairItem LanguageToLearnFrom);

public sealed record LearningLanguagePairItem(long Id, string Code);
