namespace Laraue.Apps.LearnLanguage.Contracts;

public record ImportingWord
{
    public int Id { get; init; }
    public string Word { get; set; } = string.Empty;
    public string? Transcription { get; set; }
    public string? CefrLevel { get; set; }
    public string? Meaning { get; set; }
    public string PartOfSpeech { get; set; } = string.Empty;
    public int Frequency { get; set; }
    public string[] Topics { get; set; } = [];
    public List<ImportingTranslation> Translations { get; set; } = new();
}