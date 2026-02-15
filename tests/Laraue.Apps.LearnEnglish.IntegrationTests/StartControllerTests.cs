using Telegram.Bot.Types;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public class StartControllerTests : IntegrationTest
{
    [Fact]
    public async Task Start_ShouldNotAddUtmLabel_WhenNoUtmLabelPassedInQuery()
    {
        using var telegramTestHost = GetTelegramTestHost();

        await telegramTestHost.SendUpdateAsync(new Update
        {
            Message = new Message
            {
                Text = "/start",
                From = DefaultUser
            }
        });

        Assert.Single(telegramTestHost.Get(db => db.Users.ToList()));
        Assert.Empty(telegramTestHost.Get(db => db.UtmLabels.ToArray()));
    }
    
    [Fact]
    public async Task Start_ShouldAddUtmLabel_WhenUtmLabelIsPassedInQuery()
    {
        using var telegramTestHost = GetTelegramTestHost();

        await telegramTestHost.SendUpdateAsync(new Update
        {
            Message = new Message
            {
                Text = "/start source-city1_lang-en",
                From = DefaultUser
            }
        });

        var user = Assert.Single(telegramTestHost.Get(db => db.Users.ToArray()));
        
        var dbLabels = telegramTestHost.Get(db => db.UtmLabels.ToList());
        Assert.Equal(2, dbLabels.Count);
        Assert.All(dbLabels, label => Assert.Equal(user.Id, label.UserId));
        Assert.Contains(dbLabels, l => l is { Name: "source", Value: "city1" });
        Assert.Contains(dbLabels, l => l is { Name: "lang", Value: "en" });
    }
}