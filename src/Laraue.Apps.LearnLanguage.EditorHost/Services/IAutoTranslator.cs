using Laraue.Crawling.Abstractions;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IAutoTranslator
{
    Task<TranslationResult> TranslateAsync(TranslationData translationData);
}

public record TranslationData
{
    public required string PartOfSpeech { get; set; }
    public required string Word { get; set; }
    public required string FromLanguage { get; set; }
    public required string[] ToLanguages { get; set; }
}

public record TranslationResult : ICrawlingModel
{
    public required int Frequency { get; set; }
    public required string Transcription { get; set; }
    public required string Meaning { get; set; }
    public required Dictionary<string, TranslationResultItem> Items { get; set; } = new ();
    
    public required string[] Topics { get; set; }
}

public record TranslationResultItem : ICrawlingModel
{
    public required string? Translation { get; set; }
    public required string? Transcription { get; set; }
}