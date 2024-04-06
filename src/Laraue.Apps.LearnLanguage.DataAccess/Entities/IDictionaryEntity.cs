namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public interface IDictionaryEntity
{
    public long Id { get; set; }
    public string Name { get; init; }
}