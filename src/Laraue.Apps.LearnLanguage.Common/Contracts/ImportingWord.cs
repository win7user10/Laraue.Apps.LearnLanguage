namespace Laraue.Apps.LearnLanguage.Common.Contracts;

public record ImportingWord
{
    public int Id { get; init; }
    public string Word { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string? Transcription { get; set; }
    public List<ImportingMeaning> Meanings { get; set; } = new();
}