namespace Laraue.Apps.LearnLanguage.Services.Services;

public record CreateRepeatingParameters
{
    public long WordTranslationId { get; set; }
    
    public bool IsRemembered { get; set; }
}