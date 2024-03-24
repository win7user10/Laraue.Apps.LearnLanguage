using Laraue.Apps.LearnLanguage.DataAccess;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class DictionariesService : IDictionariesService
{
    public Task<ICollection<DictionaryItemDto>> GetLanguagesAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.WordLanguages.Items
            .Select(DictionaryItemDto.Create).ToList());
    }

    public Task<ICollection<DictionaryItemDto>> GetPartsOfSpeechesAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.PartOfSpeeches.Items
            .Select(DictionaryItemDto.Create).ToList());
    }
    
    public Task<ICollection<DictionaryItemDto>> GetTopicsAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.WordTopics.Items
            .Select(DictionaryItemDto.Create).ToList());
    }
    
    public Task<ICollection<DictionaryItemDto>> GetCefrLevelsAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.CefrLevels.Items
            .Select(DictionaryItemDto.Create).ToList());
    }
}