namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTranslation : BaseEntity
{
    public long WordId { get; set; }

    public Word Word { get; set; }

    public string Translation { get; set; }
    
    public long LanguageId { get; set; }

    public TranslationLanguage Language { get; set; }

    /// <summary>
    /// Average attempts required to learn this word.
    /// </summary>
    public double? AverageAttempts { get; set; }

    /// <summary>
    /// Word translation learn difficulty based on <see cref="AverageAttempts"/>.
    /// </summary>
    public WordTranslationDifficulty? Difficulty { get; set; }
}

public enum WordTranslationDifficulty
{
    Easy,
    Medium,
    Hard,
    ExtraHard,
    Impossible,
}