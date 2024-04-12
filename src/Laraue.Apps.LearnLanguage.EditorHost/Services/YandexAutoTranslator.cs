using Laraue.Crawling.Abstractions;
using Laraue.Crawling.Dynamic.PuppeterSharp;
using Laraue.Crawling.Dynamic.PuppeterSharp.Utils;
using PuppeteerSharp;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class YandexAutoTranslator(ILoggerFactory loggerFactory, IBrowserFactory browserFactory) : IAutoTranslator
{
    private readonly ICompiledDocumentSchema<IElementHandle, HtmlSelector, TranslationResultItem> _translationSchema =
        new PuppeterSharpSchemaBuilder<TranslationResultItem>()
            .HasProperty(x => x.Translation, ".translation-word.translation-chunk")
            .Build();
    
    private readonly ICompiledDocumentSchema<IElementHandle, HtmlSelector, TranslationResult> _transcriptionSchema =
        new PuppeterSharpSchemaBuilder<TranslationResult>()
            .HasProperty(
                x => x.Transcription,
                "#dictionary > div > ul > li:nth-child(1) > div > span:nth-child(2)",
                e => e.GetInnerTextAsync()
                    .AwaitAndModify(innerText => innerText?
                        .Replace("[", string.Empty)
                        .Replace("]", string.Empty)))
            .Build();
    
    public async Task<TranslationResult> TranslateAsync(TranslationData translationData)
    {
        var parser = new PuppeterSharpParser(loggerFactory);
        var pageParser = new PageParser(parser);
        
        var browser = await browserFactory.GetInstanceAsync();
        var page = await browser.NewPageAsync();

        var items = new Dictionary<string, TranslationResultItem>();
        foreach (var toLanguage in translationData.ToLanguages)
        {
            var url = string.Format(
                "https://translate.yandex.com/?source_lang={0}&target_lang={1}&text={2}",
                translationData.FromLanguage,
                toLanguage,
                translationData.Word);
            
            await page.GoToAsync(url);
            await Task.Delay(2000);
            var item = await pageParser.ParseAsync(page, _translationSchema);
            
            items.Add(toLanguage, item);
        }
        
        var result = await pageParser.ParseAsync(page, _transcriptionSchema);
        result.Items = items;

        return result;
    }
}