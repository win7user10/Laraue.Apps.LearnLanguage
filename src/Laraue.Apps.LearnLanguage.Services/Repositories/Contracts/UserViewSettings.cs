using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record UserViewSettings(
    WordsTemplateMode WordsTemplateMode,
    ShowWordsMode ShowWordsMode);