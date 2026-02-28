namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public sealed record LearningLanguagePair(LearningLanguagePairItem LanguageToLearn, int Count);

public sealed record LearningLanguagePairItem(long Id, string Code, string Title);
