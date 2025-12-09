using Laraue.Apps.LearnLanguage.DataAccess;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class DictionariesService : IDictionariesService
{
    public Task<ICollection<DictionaryItemDto>> GetLanguagesAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.GetWordLanguages().Items
            .Select(DictionaryItemDto.Create).ToList());
    }

    public Task<ICollection<DictionaryItemDto>> GetPartsOfSpeechesAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.GetPartOfSpeeches().Items
            .Select(DictionaryItemDto.Create).ToList());
    }
    
    public Task<ICollection<DictionaryItemDto>> GetTopicsAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.GetWordTopics().Items
            .Select(DictionaryItemDto.Create).ToList());
    }
    
    public Task<ICollection<DictionaryItemDto>> GetCefrLevelsAsync()
    {
        return Task.FromResult((ICollection<DictionaryItemDto>)DefaultContextData.CefrLevels.Items
            .Select(DictionaryItemDto.Create).ToList());
    }
}