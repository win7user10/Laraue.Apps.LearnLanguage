namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public record UpdateWordDto
{
    public long? Id { get; init; }
    public required string Word { get; init; }
    public required string? CefrLevel { get; init; }
    public required string PartOfSpeech { get; init; }
    public required string Transcription { get; init; }
    public required string Meaning { get; init; }
    public required int Frequency { get; init; }
    public required string[] Topics { get; init; }
}