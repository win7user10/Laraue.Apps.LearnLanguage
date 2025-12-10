namespace Laraue.Apps.LearnLanguage.Contracts;

public record TranslationIdentifier
{
    public long WordId { get; init; }
    public long LanguageId { get; init; }
}

public interface IHasWordReference
{
    public long WordId { get; }
}

public interface IHasTranslationReference : IHasWordReference
{
    public long LanguageId { get; }
}