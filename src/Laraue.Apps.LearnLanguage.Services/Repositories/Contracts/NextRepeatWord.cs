namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record NextRepeatWordTranslation
{
    public long Id { get;set; }
    public string Name { get;set; }
    public string Translation { get;set; }
    public DateTime? LearnedAt { get;set; }
    public DateTime? RepeatedAt { get;set; }
    public int LearnAttempts { get;set; }
}
    
