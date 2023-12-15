using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record UserSettings(
    WordsTemplateMode WordsTemplateMode,
    ShowWordsMode ShowWordsMode,
    long[]? LastOpenedWordTranslationIds);