using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laraue.Apps.LearnLanguage.EditorHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DictionariesController(IDictionariesService dictionariesService) : ControllerBase, IDictionariesService
{
    [HttpGet("languages")]
    public Task<ICollection<DictionaryItemDto>> GetLanguagesAsync()
    {
        return dictionariesService.GetLanguagesAsync();
    }
    
    [HttpGet("parts-of-speeches")]
    public Task<ICollection<DictionaryItemDto>> GetPartsOfSpeechesAsync()
    {
        return dictionariesService.GetPartsOfSpeechesAsync();
    }
    
    [HttpGet("topics")]
    public Task<ICollection<DictionaryItemDto>> GetTopicsAsync()
    {
        return dictionariesService.GetTopicsAsync();
    }
    
    [HttpGet("cefr-levels")]
    public Task<ICollection<DictionaryItemDto>> GetCefrLevelsAsync()
    {
        return dictionariesService.GetCefrLevelsAsync();
    }
}