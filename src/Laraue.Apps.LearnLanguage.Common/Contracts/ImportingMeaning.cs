namespace Laraue.Apps.LearnLanguage.Common.Contracts;

public record ImportingMeaning(
    int Id,
    string? Meaning,
    string? Level,
    string[] Topics,
    string[] PartsOfSpeech,
    ImportingMeaningTranslation[] Translations);