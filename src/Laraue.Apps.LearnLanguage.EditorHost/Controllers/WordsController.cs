using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Core.DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Laraue.Apps.LearnLanguage.EditorHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController(IWordsService wordsService) : ControllerBase
{
    [HttpGet]
    public Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync([FromQuery] GetWordsRequest request)
    {
        return wordsService.GetWordsAsync(request);
    }
    
    [HttpPost]
    public Task<long> UpsertWordAsync([FromBody] UpdateWordDto wordDto)
    {
        return wordsService.UpsertWordAsync(wordDto);
    }
    
    [HttpPost("{wordId:int}/Translations")]
    public Task<long> UpsertTranslationAsync(int wordId, [FromBody] UpdateTranslationDto updateTranslationDto)
    {
        return wordsService.UpsertTranslationAsync(wordId, updateTranslationDto);
    }
    
    [HttpDelete("{wordId:int}/Translations/{translationCode}")]
    public Task DeleteTranslationAsync(int wordId, string translationCode)
    {
        return wordsService.DeleteTranslationAsync(wordId, translationCode);
    }
    
    [HttpDelete("{wordId:int}")]
    public Task DeleteWordAsync(int wordId)
    {
        return wordsService.DeleteWordAsync(wordId);
    }
}