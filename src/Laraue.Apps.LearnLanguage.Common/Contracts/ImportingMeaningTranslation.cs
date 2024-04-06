namespace Laraue.Apps.LearnLanguage.Common.Contracts;

public record ImportingMeaningTranslation
{
    public int Id { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}