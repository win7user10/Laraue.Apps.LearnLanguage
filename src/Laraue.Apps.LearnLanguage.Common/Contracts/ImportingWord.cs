namespace Laraue.Apps.LearnLanguage.Common.Contracts;

public record ImportingWord(
    int Id,
    string Word,
    string Language,
    string? Transcription,
    ImportingMeaning[] Meanings);