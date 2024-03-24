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
    
    [HttpPost("{wordId:int}/Meaning")]
    public Task<long> UpsertMeaningAsync(int wordId, [FromBody] UpdateMeaningDto updateMeaningDto)
    {
        return wordsService.UpsertMeaningAsync(wordId, updateMeaningDto);
    }
    
    [HttpPost("{wordId:int}/Meaning/{meaningId:int}/Translation")]
    public Task<long> UpsertTranslationAsync(int wordId, int meaningId, [FromBody] UpdateTranslationDto updateTranslationDto)
    {
        return wordsService.UpsertTranslationAsync(wordId, meaningId, updateTranslationDto);
    }
}