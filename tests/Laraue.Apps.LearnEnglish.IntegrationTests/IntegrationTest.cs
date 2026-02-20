using Laraue.Apps.LearnLanguage.AppServices.Services;
using Laraue.Apps.LearnLanguage.Host;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Telegram.Bot.Types;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

[Collection("IntegrationTest")]
public class IntegrationTest
{
    protected static AppTelegramTestHost GetTelegramTestHost()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Configuration.AddJsonFile("appsettings.json");
            
        builder
            .AddTelegramOptions("Telegram")
            .AddApplicationServices()
            .AddDatabaseServices("Postgre");
        
        var appServices = builder
            .Services
            .Replace(
                new ServiceDescriptor(
                    typeof(IQuestionsOrderRandomizer), 
                    null,
                    typeof(DeterminedOrderRandomizer),
                    ServiceLifetime.Singleton));
        
        return new AppTelegramTestHost(appServices);
    }

    protected static User DefaultUser => new()
    {
        Id = 1,
        Username = "user1",
    };

    private class DeterminedOrderRandomizer : IQuestionsOrderRandomizer
    {
        public IQueryable<NewQuestionDto> InRandomOrder(IQueryable<NewQuestionDto> queryable)
        {
            return queryable
                .OrderBy(x => x.WordId)
                .ThenBy(x => x.PartOfSpeechId);
        }

        public IEnumerable<NewQuestionDto> InRandomOrder(IEnumerable<NewQuestionDto> enumerable)
        {
            return InRandomOrder(enumerable.AsQueryable());
        }
    }
}

