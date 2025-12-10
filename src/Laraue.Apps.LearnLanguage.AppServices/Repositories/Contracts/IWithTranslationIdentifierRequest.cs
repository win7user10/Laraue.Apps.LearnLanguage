namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public interface IWithTranslationIdentifierRequest
{
    public long? WordId { get; }
    public long? LanguageId { get;  }
}