namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record UserSettings(
    string? InterfaceLanguageCode,
    long? LanguageToLearnId,
    string? LanguageToLearnCode);