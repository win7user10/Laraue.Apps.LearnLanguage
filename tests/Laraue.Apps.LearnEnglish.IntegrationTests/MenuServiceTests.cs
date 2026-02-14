using Telegram.Bot.Types;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public class MenuServiceTests : IntegrationTest
{
    [Fact]
    public async Task Start_ShouldNotAddUtmLabel_WhenNoUtmLabelPassedInQuery()
    {
        await using var telegramTestHost = GetTelegramTestHost();

        await telegramTestHost.SendUpdateAsync(new Update
        {
            Message = new Message
            {
                Text = "/start",
                From = DefaultUser
            }
        });

        Assert.Single(telegramTestHost.GetDbSet(db => db.Users));
        Assert.Empty(telegramTestHost.GetDbSet(db => db.UtmLabels));
    }
    
    [Fact]
    public async Task Start_ShouldAddUtmLabel_WhenUtmLabelIsPassedInQuery()
    {
        await using var telegramTestHost = GetTelegramTestHost();

        await telegramTestHost.SendUpdateAsync(new Update
        {
            Message = new Message
            {
                Text = "/start source-city1_lang-en",
                From = DefaultUser
            }
        });

        var user = Assert.Single(telegramTestHost.GetDbSet(db => db.Users));
        
        var dbLabels = telegramTestHost.GetDbSet(db => db.UtmLabels).ToList();
        Assert.Equal(2, dbLabels.Count);
        Assert.All(dbLabels, label => Assert.Equal(user.Id, label.UserId));
        Assert.Contains(dbLabels, l => l is { Name: "source", Value: "city1" });
        Assert.Contains(dbLabels, l => l is { Name: "lang", Value: "en" });
    }
}