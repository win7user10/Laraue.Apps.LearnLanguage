using System;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.Commands.Jobs;
using Laraue.Apps.LearnLanguage.Common.Services;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
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

        var wordGroup = new WordGroup
        {
            SerialNumber = 1,
            UserId = Users.User1.Id,
        };

        var wordGroupWordTranslations = new WordGroupWords[]
        {
            new()
            {
                WordGroup = wordGroup,
                LearnedAt = new DateTimeOffset(new DateTime(2022, 01, 02), TimeSpan.Zero),
                WordTranslationId = 1,
            },
            new()
            {
                WordGroup = wordGroup,
                LearnedAt = new DateTimeOffset(new DateTime(2022, 01, 01), TimeSpan.Zero),
                WordTranslationId = 2,
            }
        };
        
        DbContext.WordGroups.Add(wordGroup);
        DbContext.WordGroupWordTranslations.AddRange(wordGroupWordTranslations);
        await DbContext.SaveChangesAsync();
        
        await _job.ExecuteAsync();
        
        _telegramBotClientMock.Verify(
            x => x.MakeRequestAsync(
                It.Is<SendMessageRequest>(y => y.ChatId == Users.User1.TelegramId),
                default));
    }
}