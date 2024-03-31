namespace Laraue.Apps.LearnLanguage.Common;

public record TranslationIdentifier
{
    public long WordId { get; init; }
    public long MeaningId { get; init; }
    public long TranslationId { get; init; }
}

public interface IHasWordReference
{
    public long WordId { get; }
}

public interface IHasMeaningReference : IHasWordReference
{
    public long MeaningId { get; }
}

public interface IHasTranslationReference : IHasMeaningReference
{
    public long TranslationId { get; }
}