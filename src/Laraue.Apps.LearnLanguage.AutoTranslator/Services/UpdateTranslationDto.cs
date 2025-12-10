namespace Laraue.Apps.LearnLanguage.AutoTranslator.Services;

public record UpdateTranslationDto(string Language, string Text, string? Transcription);