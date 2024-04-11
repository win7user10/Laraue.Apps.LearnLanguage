using Laraue.Crawling.Dynamic.PuppeterSharp;
using Laraue.Crawling.Dynamic.PuppeterSharp.Utils;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class GoogleAutoTranslator(ILoggerFactory loggerFactory, IBrowserFactory browserFactory) : IAutoTranslator
{
    private readonly Dictionary<string, string> _languageNames = new()
    {
        ["en"] = "English",
        ["ru"] = "Russian",
        ["fr"] = "French",
    };
    
    public async Task<TranslationResult> TranslateAsync(TranslationData translationData)
    {
        var schema = new PuppeterSharpSchemaBuilder<TranslationResult>()
            .BindManually(async (element, binder) =>
            {
                var textArea = (await element.QuerySelectorAllAsync("textarea"))[1];
                
                // Wait for textarea load
                await Task.Delay(500);
                await textArea.TypeAsync(translationData.Word);

                // Find the button with the source language and click it
                var sourceLanguageButtons = await element.QuerySelectorAllAsync(".language-list:nth-child(3) div .tw-lliw");
                foreach (var languageButton in sourceLanguageButtons)
                {
                    if (await languageButton.GetInnerTextAsync() == _languageNames[translationData.FromLanguage])
                    {
                        await languageButton.EvaluateFunctionAsync("e => e.click()");
                    }
                }

                var result = new Dictionary<string, TranslationResultItem>();
                
                // Find the button with the target language and click it
                var targetLanguageButtons = await element.QuerySelectorAllAsync(".language-list:nth-child(2) .tw-lls:nth-child(2) .language_list_item");
                foreach (var languageButton in targetLanguageButtons)
                {
                    var innerText = await languageButton.GetInnerTextAsync();
                    foreach (var toLanguage in translationData.ToLanguages)
                    {
                        if (innerText == _languageNames[toLanguage])
                        {
                            await languageButton.EvaluateFunctionAsync("e => e.click()");
                            
                            // Time to make translation
                            await Task.Delay(500);
                            var translationArea = await element.QuerySelectorAsync("#tw-target-text span");
                            result[toLanguage] = new TranslationResultItem
                            {
                                Translation = await translationArea.GetInnerTextAsync()
                            };
                        }
                    }
                }
                
                binder.BindProperty(x => x.Items, result);
            });

        var browser = await browserFactory.GetInstanceAsync();
        var page = await browser.NewPageAsync();
        await page.GoToAsync("https://www.google.com/search?q=translate&hl=en");

        var parser = new PuppeterSharpParser(loggerFactory);
        var pageParser = new PageParser(parser);
        var result = await pageParser.ParseAsync(page, schema.Build());

        return result;
    }
}