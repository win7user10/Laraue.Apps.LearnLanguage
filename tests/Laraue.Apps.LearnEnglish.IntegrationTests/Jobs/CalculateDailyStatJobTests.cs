using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Jobs;
using Laraue.Core.DateTime.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Jobs;

public class CalculateDailyStatJobTests : TestWithDatabase
{
    private readonly CalculateDailyStatJob _job;
    private readonly Mock<ITelegramBotClient> _telegramBotClientMock;
    private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
    
    public CalculateDailyStatJobTests()
    {
        _telegramBotClientMock = new Mock<ITelegramBotClient>();
        _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        
        var serviceProvider = ServiceCollection
            .AddScoped<CalculateDailyStatJob>()
            .AddSingleton(_telegramBotClientMock.Object)
            .AddSingleton(_dateTimeProviderMock.Object)
            .BuildServiceProvider();
            
        _job = serviceProvider.GetRequiredService<CalculateDailyStatJob>();
    }
    
    [Fact]
    public async Task JobShouldTakeUsersCorrectlyAsync()
    {
        _dateTimeProviderMock.Setup(x => x.UtcNow)
            .Returns(new DateTime(2022, 01, 02));

        var translationStates = new WordTranslationState[]
        {
            new()
            {
                LearnedAt = new DateTime(2022, 01, 02),
                WordTranslationId = 1,
                UserId = Users.User1.Id,
            },
            new()
            {
                LearnedAt = new DateTime(2022, 01, 01),
                WordTranslationId = 2,
                UserId = Users.User1.Id
            }
        };

        var wordGroup = new WordGroup
        {
            UserId = Users.User1.Id,
            SerialNumber = 1,
            WordGroupWords = new List<WordGroupWord>
            {
                new()
                {
                    WordTranslationId = 1,
                    SerialNumber = 1
                },
                new()
                {
                    WordTranslationId = 2,
                    SerialNumber = 2
                },
                new()
                {
                    WordTranslationId = 3,
                    SerialNumber = 3
                }
            }
        };
        
        DbContext.WordTranslationStates.AddRange(translationStates);
        DbContext.WordGroups.Add(wordGroup);
        await DbContext.SaveChangesAsync();
        
        await _job.ExecuteAsync();
        
        var sendMessageRequest = _telegramBotClientMock.Invocations
            .First(x => x.Method.Name == nameof(ITelegramBotClient.MakeRequestAsync))
            .Arguments[0] as SendMessageRequest;
            
        Assert.Equal(Users.User1.TelegramId, sendMessageRequest!.ChatId);
        
        const string exceptedText = "Yesterday you have been learned 1 words!\n" +
                                    "Total stat is 2 / 3 (+33.33%)";
        Assert.Equal(exceptedText, sendMessageRequest.Text);
    }
}