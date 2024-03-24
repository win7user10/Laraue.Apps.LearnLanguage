namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public record UpdateWordDto
{
    public long? Id { get; init; }
    public required string Word { get; init; }
    public required string Language{ get; init; }
    public string? Transcription { get; init; }
}