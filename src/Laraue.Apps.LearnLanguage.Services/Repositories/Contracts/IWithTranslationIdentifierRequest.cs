namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public interface IWithTranslationIdentifierRequest
{
    public long? WordId { get; }
    public long? MeaningId { get; }
    public long? TranslationId { get;  }
}