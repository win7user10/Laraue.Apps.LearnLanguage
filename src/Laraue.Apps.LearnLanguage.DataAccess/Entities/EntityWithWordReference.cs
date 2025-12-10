using Laraue.Apps.LearnLanguage.Contracts;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public interface IEntityWithWordReference : IHasWordReference
{
    public Word Word { get; set; }
}

public interface IEntityWithTranslationReference : IEntityWithWordReference, IHasTranslationReference
{
    public Translation Translation { get; set; }
}