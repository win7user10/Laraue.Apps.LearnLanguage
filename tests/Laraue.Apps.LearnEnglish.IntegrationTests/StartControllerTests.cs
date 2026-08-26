using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
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
                From = DefaultUser,
                Chat = new Chat
                {
                    Id = 1,
                    Type = ChatType.Private,
                }
            }
        });

        Assert.Single(telegramTestHost.GetFromDb(db => db.Users.ToList()));
        Assert.Empty(telegramTestHost.GetFromDb(db => db.UtmLabels.ToArray()));
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
                From = DefaultUser,
                Chat = new Chat
                {
                    Id = 1,
                    Type = ChatType.Private,
                }
            },
        });

        var user = Assert.Single(telegramTestHost.GetFromDb(db => db.Users.ToArray()));
        
        var dbLabels = telegramTestHost.GetFromDb(db => db.UtmLabels.ToList());
        Assert.Equal(2, dbLabels.Count);
        Assert.All(dbLabels, label => Assert.Equal(user.Id, label.UserId));
        Assert.Contains(dbLabels, l => l is { Name: "source", Value: "city1" });
        Assert.Contains(dbLabels, l => l is { Name: "lang", Value: "en" });
    }
}