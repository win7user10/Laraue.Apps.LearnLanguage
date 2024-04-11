using System;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Crawling.Dynamic.PuppeterSharp.Utils;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Services;

public class GoogleAutoTranslatorTests : IDisposable
{
    private readonly GoogleAutoTranslator _translator;
    private readonly BrowserFactory _browserFactory;
    
    public GoogleAutoTranslatorTests()
    {
        Environment.SetEnvironmentVariable("LANG", "en");
        
        _browserFactory = new BrowserFactory(
            new LaunchOptions
            {
                Headless = false,
                Args = ["--lang='en-US'"]
            }, new LoggerFactory());
        _translator = new GoogleAutoTranslator(
            new LoggerFactory(),
            _browserFactory);
    }

    [Fact]
    public async Task TestAsync()
    {
        var translationResult = await _translator.TranslateAsync(new TranslationData
        {
            Word = "Dog",
            FromLanguage = "en",
            ToLanguages = ["ru", "fr"]
        });
        
        Assert.Equal("Собака", translationResult.Items["ru"].Translation);
        Assert.Equal("Chien", translationResult.Items["fr"].Translation);
    }

    public void Dispose()
    {
        _browserFactory.Dispose();
    }
}