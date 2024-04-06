namespace Laraue.Apps.LearnLanguage.Common.Contracts;

public record ImportingMeaning
{
    public int Id { get; set; }
    public string? Meaning { get; set; }
    public string? Level { get; set; }
    public string[] Topics { get; set; } = Array.Empty<string>();
    public string[] PartsOfSpeech { get; set; } = Array.Empty<string>();
    public List<ImportingMeaningTranslation> Translations { get; set; } = new();
}