namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IDictionariesService
{
    Task<ICollection<DictionaryItemDto>> GetLanguagesAsync();
    Task<ICollection<DictionaryItemDto>> GetPartsOfSpeechesAsync();
    Task<ICollection<DictionaryItemDto>> GetTopicsAsync();
    Task<ICollection<DictionaryItemDto>> GetCefrLevelsAsync();
}