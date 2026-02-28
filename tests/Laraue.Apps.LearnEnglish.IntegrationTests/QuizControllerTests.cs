using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Testing;
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
                .HasButtonsRow(new ButtonAssert("English < - > German", "quiz?lt=6"))
                .HasButtonsRow(new ButtonAssert("English < - > Spanish", "quiz?lt=5"))
                .HasButtonsRow(new ButtonAssert("English < - > French", "quiz?lt=3"))
                .HasButtonsRow(new ButtonAssert("English < - > Hindi", "quiz?lt=8"))
                .HasButtonsRow(new ButtonAssert("English < - > Japanese", "quiz?lt=4"))
                .HasButtonsRow(new ButtonAssert("English < - > Russian", "quiz?lt=2"))
                .HasButtonsRow(new ButtonAssert("English < - > Chinese", "quiz?lt=7"))
                .HasButtonsRow(new ButtonAssert("Menu", "m")));
    }
    
    [Fact]
    public async Task CurrentQuiz_ShouldOpenStartWindow_WhenLanguageSetInSettings()
    {
        using var telegramTestHost = GetTelegramTestHost();
        telegramTestHost.InsertIntoDb(new User
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
    
    [Fact]
    public async Task StartQuiz_ShouldStartQuizAndPrintFirstQuestion_Always()
    {
        using var telegramTestHost = GetTelegramTestHost();
        var ruLanguageId = DefaultContextData.GetWordLanguages().GetId("ru");

        await telegramTestHost.SendUpdateAsync(new Update
        {
            CallbackQuery = new CallbackQuery
            {
                From = DefaultUser,
                Data = new CallbackRoutePath(TelegramRoutes.StartQuiz, RouteMethod.Post)
                    .WithTranslationDirection(new SelectedTranslation(ruLanguageId)),
                Message = new Message
                {
                    Id = 1
                }
            }
        });

        var request = telegramTestHost
            .Requests()
            .Single<EditMessageTextRequest>();

        var firstQuestionOfQuiz = telegramTestHost.GetFromDb(db => db
            .UserQuizQuestions
            .OrderBy(q => q.Id)
            .First());

        var questionId = firstQuestionOfQuiz.Id;
        
        request.CheckMessage(
            """
            Question <b>1/20</b>
            Select the translation for <b>a</b> (indefinite article, A1)
            """);
        
        request.CheckButtonsSequentially(buttons => 
            buttons
                .HasButtonsRow(
                    new ButtonAssert("Аборт", $"1 sa?q={questionId}&a=6"),
                    new ButtonAssert("О", $"1 sa?q={questionId}&a=8"))
                .HasButtonsRow(
                    new ButtonAssert("Один", $"1 sa?q={questionId}&a=1"),
                    new ButtonAssert("Около", $"1 sa?q={questionId}&a=7"))
                .HasButtonsRow(
                    new ButtonAssert("Отменить", $"1 sa?q={questionId}&a=5"),
                    new ButtonAssert("Покидать", $"1 sa?q={questionId}&a=2"))
                .HasButtonsRow(
                    new ButtonAssert("Способность", $"1 sa?q={questionId}&a=3"),
                    new ButtonAssert("Способный", $"1 sa?q={questionId}&a=4"))
                .HasButtonsRow(new ButtonAssert("Skip", $"1 sa?q={questionId}&a=0"))
                .HasButtonsRow(new ButtonAssert("Finish quiz", "1 fq"))
                .HasButtonsRow(new ButtonAssert("Menu", "m"))
            );

        var quiz = Assert.Single(telegramTestHost.GetFromDb(x => x.UserQuizzes.ToArray()));
        Assert.Equal(ruLanguageId, quiz.LanguageId);
        Assert.Null(quiz.FinishedAt);

        var quizQuestions = telegramTestHost.GetFromDb(x => x.UserQuizQuestions.ToArray());
        Assert.Equal(20, quizQuestions.Length);
    }
}