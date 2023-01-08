namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTranslation : BaseEntity
{
    public long WordId { get; set; }

    public Word Word { get; set; }

    public string Translation { get; set; }
    
    public long LanguageId { get; set; }

    public Language Language { get; set; }
}