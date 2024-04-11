using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laraue.Apps.LearnLanguage.EditorHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UtilsController(IAutoTranslator autoTranslator) : ControllerBase
{
    [HttpPost("translate")]
    public Task<TranslationResult> TranslateAsync([FromBody] TranslationData translationData)
    {
        return autoTranslator.TranslateAsync(translationData);
    }
}