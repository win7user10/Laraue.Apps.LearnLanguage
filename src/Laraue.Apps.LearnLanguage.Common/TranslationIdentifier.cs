namespace Laraue.Apps.LearnLanguage.Common;

public record TranslationIdentifier
{
    public long WordId { get; init; }
    public long TranslationId { get; init; }
}

public interface IHasWordReference
{
    public long WordId { get; }
}

public interface IHasTranslationReference : IHasWordReference
{
    public long TranslationId { get; }
}