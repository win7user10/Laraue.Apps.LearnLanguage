using Laraue.Apps.LearnLanguage.Common;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public interface IEntityWithWordReference : IHasWordReference
{
    public Word Word { get; set; }
}

public interface IEntityWithMeaningReference : IEntityWithWordReference, IHasMeaningReference
{
    public Meaning Meaning { get; set; }
}

public interface IEntityWithTranslationReference : IEntityWithMeaningReference, IHasTranslationReference
{
    public Translation Translation { get; set; }
}