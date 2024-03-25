namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public record UpdateMeaningDto
{
    public long? Id { get; init; }
    public string? Meaning { get; init; }
    public string[] PartsOfSpeech { get; init; } = Array.Empty<string>();
    public string[] Topics { get; init; } = Array.Empty<string>();
    public string? Level { get; init; }
}