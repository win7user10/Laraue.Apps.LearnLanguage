namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record struct SelectedTranslation(long? LanguageToLearnId, long? LanguageToLearnFromId);