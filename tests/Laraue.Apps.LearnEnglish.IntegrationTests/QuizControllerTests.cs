using Laraue.Apps.LearnEnglish.IntegrationTests.Library;
using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.DataAccess;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Xunit;
using User = Laraue.Apps.LearnLanguage.DataAccess.Entities.User;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public class QuizControllerTests : IntegrationTest
{
    [Fact]
    public async Task CurrentQuiz_ShouldAskLanguagePair_WhenItIsNotSetInSettings()
    {
        using var telegramTestHost = GetTelegramTestHost();

        await telegramTestHost.SendUpdateAsync(new Update
        {
            CallbackQuery = new CallbackQuery
            {
                From = DefaultUser,
                Data = TelegramRoutes.CurrentQuiz,
                Message = new Message
                {
                    Id = 1
                }
            }
        });

        const string excepted =
"""
<b>Quiz Mode</b>

Select the language pair. You also can set the preferred language pair in settings to select the same pair always.
""";

        var request = telegramTestHost
            .Requests()
            .Single<EditMessageTextRequest>();
        
        request.CheckMessage(excepted);
        request.CheckButtonsSequentially(assert =>
            assert
                .HasButtonsRow(new ButtonAssert("en < - > hi (5948)", "quiz?lt=8"))
                .HasButtonsRow(new ButtonAssert("en < - > es (5948)", "quiz?lt=5"))
                .HasButtonsRow(new ButtonAssert("en < - > ja (5948)", "quiz?lt=4"))
                .HasButtonsRow(new ButtonAssert("en < - > zh (5948)", "quiz?lt=7"))
                .HasButtonsRow(new ButtonAssert("en < - > de (5948)", "quiz?lt=6"))
                .HasButtonsRow(new ButtonAssert("en < - > ru (5948)", "quiz?lt=2"))
                .HasButtonsRow(new ButtonAssert("en < - > fr (5948)", "quiz?lt=3"))
                .HasButtonsRow(new ButtonAssert("Menu", "m")));
    }
    
    
    [Fact]
    public async Task CurrentQuiz_ShouldOpenStartWindow_WhenLanguageSetInSettings()
    {
        using var telegramTestHost = GetTelegramTestHost();
        await telegramTestHost.InsertIntoDbAsync(new User
        {
            TelegramId = DefaultUser.Id,
            LanguageToLearnId = DefaultContextData.GetWordLanguages().GetId("ru")
        });

        await telegramTestHost.SendUpdateAsync(new Update
        {
            CallbackQuery = new CallbackQuery
            {
                From = DefaultUser,
                Data = TelegramRoutes.CurrentQuiz,
                Message = new Message
                {
                    Id = 1
                }
            }
        });

        var request = telegramTestHost
            .Requests()
            .Single<EditMessageTextRequest>();
        
        request.CheckMessage(
"""
<b>Quiz is ready to start</b>

Topics: <b>Not set</b>
CEFR Levels: <b>Not set</b>
Questions will be asked: <b>20</b>
Total possible questions by current criteria: <b>5948</b>
Language pair: <b>en -> ru</b>
Question options count: <b>8</b>

<b>Stats for the selected criteria</b>
Total correct answers: <b>0</b>
Total incorrect answers: <b>0</b>
Total skipped answers: <b>0</b>
Total learned: <b>0 / 5948</b>
""");
    }
}