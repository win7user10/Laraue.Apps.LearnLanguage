using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class DictionaryItemDto
{
    public required string Name { get; init; }

    public static DictionaryItemDto Create(IDictionaryEntity entity)
    {
        return new DictionaryItemDto
        {
            Name = entity.Name
        };
    }
}