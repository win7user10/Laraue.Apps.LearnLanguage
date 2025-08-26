using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Core.DataAccess.EFCore.Extensions;
using Laraue.Core.DateTime.Services.Abstractions;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class QuizService(
    QuizService.IRepository repository,
    ISelectLanguageService selectLanguageService,
    ITelegramBotClient client,
    DatabaseContext context,
    IQuestionsGenerator questionsGenerator)
    : IQuizService
{
    private const long OptionIdToSkipQuestion = 0;
    
    public async Task HandleQuizWindowAsync(ReplyData replyData, QuizRequest request, CancellationToken ct = default)
    {
        var hasActiveQuiz = await repository.HasActiveQuizAsync(replyData.UserId, ct);
        var task = hasActiveQuiz
            ? HandleCurrentQuizWindowAsync(replyData, request, ct)
            : HandleNewQuizWindowAsync(replyData, request, ct);

        await task;
    }

    private async Task HandleNewQuizWindowAsync(ReplyData replyData, QuizRequest request, CancellationToken ct = default)
    {
        await selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
            request,
            QuizMode.ButtonName,
            TelegramRoutes.CurrentQuiz,
            replyData,
            StartNewQuizAsync,
            ct);
    }
    
    private async Task StartNewQuizAsync(
        QuizRequest request,
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);
        
        var quizId = await repository.CreateQuizAsync(
            replyData.UserId,
            selectedTranslation.LanguageToLearnId!.Value,
            ct);

        // TODO - use settings to setup
        const int questionsCount = 20;
        const int optionsCount = 8;
        
        var questions = await questionsGenerator.GenerateQuestions(
            replyData.UserId,
            selectedTranslation.LanguageToLearnId!.Value,
            questionsCount,
            optionsCount,
            ct);

        await repository.SaveQuizQuestionsAsync(quizId, questions, ct);
        
        await transaction.CommitAsync(ct);
        
        await HandleCurrentQuizWindowAsync(replyData, new QuizRequest(), ct);
    }
    
    private async Task HandleCurrentQuizWindowAsync(
        ReplyData replyData,
        QuizRequest request,
        CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder();

        if (request.FinishQuiz)
        {
            await repository.SkipAllQuizQuestions(replyData.UserId, ct);
        }
        else if (request.SelectedOptionId.HasValue)
        {
            var result = await HandleSelectedOptionAsync(
                replyData.UserId,
                request.SelectedOptionId.Value,
                ct);
            
            tmb
                .Append("<b>")
                .Append(QuizMode.ResourceManager.GetString($"QuizAnswer_{result.Status}") ?? string.Empty)
                .Append("     ")
                .Append(result.QuestionDto.Word)
                .Append("     ")
                .Append(result.QuestionDto.Translation)
                .AppendRow($"     [{result.QuestionDto.Transcription}]")
                .Append("</b>")
                .AppendRow();
        }

        var stats = await repository.GetCurrentQuizStatsAsync(replyData.UserId, ct);
        if (stats.AnsweredQuestions == stats.TotalQuestions)
        {
            await HandleFinishQuizAsync(replyData, stats.Id, ct);
            return;
        }
        
        var data = await repository.GetFlashCardsAsync(stats.Id, stats.LanguageId, ct);

        tmb
            .Append(QuizMode.Question)
            .AppendRow($" <b>{stats.AnsweredQuestions}/{stats.TotalQuestions}</b>")
            .Append(QuizMode.TranslateWord)
            .AppendRow($" <b>{data.Word}</b>");

        foreach (var flashCardsChunk in data.FlashCards.Chunk(2))
        {
            tmb.AddInlineKeyboardButtons(flashCardsChunk
                .Select(x => InlineKeyboardButton.WithCallbackData(
                    System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Text),
                    new CallbackRoutePath(TelegramRoutes.CurrentQuiz)
                    .WithQueryParameter(ParameterNames.OpenedWordId, x.WordId))));
        }

        tmb.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(QuizMode.SkipButtonName, new CallbackRoutePath(TelegramRoutes.CurrentQuiz)
                .WithQueryParameter(ParameterNames.OpenedWordId, OptionIdToSkipQuestion))
        ]);
        
        tmb.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(QuizMode.FinishQuiz, new CallbackRoutePath(TelegramRoutes.CurrentQuiz)
                .WithQueryParameter(ParameterNames.FinishQuiz, true))
        ]);
        
        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    private async Task HandleFinishQuizAsync(
        ReplyData replyData,
        long quizId,
        CancellationToken ct = default)
    {
        await repository.SetQuizFinished(quizId, ct);

        var lastQuizStat = await repository.GetLastQuizStatsAsync(replyData.UserId, ct);
        var incorrectCount = lastQuizStat.TotalQuestions - lastQuizStat.CorrectAnswersCount - lastQuizStat.SkippedAnswersCount;

        var tmb = new TelegramMessageBuilder()
            .AppendRow(QuizMode.QuizFinishedTitle)
            .AppendRow()
            .Append(QuizMode.Correct)
            .Append(" - ")
            .AppendRow(lastQuizStat.CorrectAnswersCount.ToString())
            .Append(QuizMode.QuizAnswer_Skipped)
            .Append(" - ")
            .AppendRow(lastQuizStat.SkippedAnswersCount.ToString())
            .Append(QuizMode.Incorrect)
            .Append(" - ")
            .AppendRow(incorrectCount.ToString());

        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    /// <returns>True if request handled and processing should be stopped.</returns>
    private async Task<HandleSelectedOptionResponse> HandleSelectedOptionAsync(
        Guid userId,
        long selectedOptionId,
        CancellationToken ct = default)
    {
        var question = await repository.GetQuestion(userId, ct);

        var status = selectedOptionId == OptionIdToSkipQuestion
            ? UserQuizQuestionStatus.Skipped
            : selectedOptionId == question.CorrectWordId
                ? UserQuizQuestionStatus.Correct
                : UserQuizQuestionStatus.Incorrect;
        
        await repository.SetQuizQuestionStatus(question.QuestionId, status, ct);

        var increaseWinStreak = status == UserQuizQuestionStatus.Correct;
        await repository.UpdateTranslationWinStreakAsync(
            question.CorrectWordId,
            question.LanguageId,
            userId,
            increaseWinStreak,
            ct);

        return new HandleSelectedOptionResponse
        {
            Status = status,
            QuestionDto = question
        };
    }

    private class HandleSelectedOptionResponse
    {
        public required UserQuizQuestionStatus Status { get; set; }
        public required QuestionDto QuestionDto { get; set; }
    }

    public interface IRepository
    {
        Task<bool> HasActiveQuizAsync(Guid userId, CancellationToken ct = default);
        Task<long> CreateQuizAsync(Guid userId, long languageId, CancellationToken ct = default);
        Task SetQuizFinished(long quizId, CancellationToken ct = default);
        Task SaveQuizQuestionsAsync(long quizId, NewQuestionDto[] questions, CancellationToken ct = default);
        Task SkipAllQuizQuestions(Guid userId, CancellationToken ct = default);
        Task<FlashCardsDto> GetFlashCardsAsync(long quizId, long languageId, CancellationToken ct = default);
        Task<QuestionDto> GetQuestion(Guid userId, CancellationToken ct = default);
        Task SetQuizQuestionStatus(long questionId, UserQuizQuestionStatus status, CancellationToken ct = default);
        Task UpdateTranslationWinStreakAsync(long wordId, long languageId, Guid userId, bool increase, CancellationToken ct = default);
        Task<CurrentQuizStats> GetCurrentQuizStatsAsync(Guid userId, CancellationToken ct = default);
        Task<LastQuizStats> GetLastQuizStatsAsync(Guid userId, CancellationToken ct = default);
    }

    public class FlashCard
    {
        public required long WordId { get; set; }
        public required string Text { get; set; }
    }

    public class CurrentQuizStats
    {
        public long Id { get; set; }
        public long LanguageId { get; set; }
        public int TotalQuestions { get; set; }
        public int AnsweredQuestions { get; set; }
    }
    
    public class LastQuizStats
    {
        public int TotalQuestions { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int SkippedAnswersCount { get; set; }
    }
    
    public class FlashCardsDto
    {
        public required string Word { get; set; }
        public required FlashCard[] FlashCards { get; set; }
    }

    public class QuestionDto
    {
        public long CorrectWordId { get; init; }
        public long QuestionId { get; init; }
        public required string Word { get; init; }
        public required string Translation { get; init; }
        public required string? Transcription { get; init; }
        public required long LanguageId { get; init; }
    }
    
    public class Repository(DatabaseContext context, IDateTimeProvider dateTimeProvider) : IRepository
    {
        public Task<bool> HasActiveQuizAsync(Guid userId, CancellationToken ct = default)
        {
            return context.UserQuizzes
                .Where(x => x.UserId == userId)
                .Where(x => x.Status == UserQuizStatus.Active)
                .AnyAsyncLinqToDB(ct);
        }

        public async Task<long> CreateQuizAsync(Guid userId, long languageId, CancellationToken ct = default)
        {
            var quiz = new UserQuiz
            {
                UserId = userId,
                Status = UserQuizStatus.Active,
                CreatedAt = dateTimeProvider.UtcNow,
                LanguageId = languageId,
            };
            
            context.Add(quiz);
            
            await context.SaveChangesAsync(ct);
            
            return quiz.Id;
        }

        public Task SetQuizFinished(long quizId, CancellationToken ct = default)
        {
            return context.UserQuizzes
                .Where(q => q.Id == quizId)
                .ExecuteUpdateAsync(update => update
                        .SetProperty(x => x.Status, UserQuizStatus.Finished)
                        .SetProperty(x => x.FinishedAt, dateTimeProvider.UtcNow),
                    ct);
        }

        public async Task SaveQuizQuestionsAsync(
            long quizId,
            NewQuestionDto[] questions,
            CancellationToken ct = default)
        {
            foreach (var question in questions)
            {
                var entity = new UserQuizQuestion
                {
                    WordId = question.WordId,
                    Status = UserQuizQuestionStatus.New,
                    QuizId = quizId,
                    OptionIds = question.OptionIds,
                };
                
                context.UserQuizQuestions.Add(entity);
            }

            await context.SaveChangesAsync(ct);
        }

        public Task SkipAllQuizQuestions(Guid userId, CancellationToken ct = default)
        {
            return context.UserQuizQuestions
                .Where(x => x.Quiz.UserId == userId)
                .Where(x => x.Quiz.Status == UserQuizStatus.Active)
                .Where(x => x.Status == UserQuizQuestionStatus.New)
                .UpdateAsync(question => new UserQuizQuestion
                {
                    Status = UserQuizQuestionStatus.Skipped,
                    AnsweredAt = dateTimeProvider.UtcNow,
                }, ct);
        }

        public async Task<FlashCardsDto> GetFlashCardsAsync(long quizId, long languageId, CancellationToken ct = default)
        {
            var nextQuizQuestion = await context.UserQuizQuestions
                .Where(x => x.QuizId == quizId)
                .Where(x => x.Status == UserQuizQuestionStatus.New)
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    x.OptionIds,
                    x.Word.Text
                })
                .FirstOrThrowNotFoundEFAsync(ct);

            var flashCards = await context.Translations
                .Where(x => x.LanguageId == languageId)
                .Where(x => nextQuizQuestion.OptionIds.Contains(x.WordId))
                .Select(x => new FlashCard
                {
                    WordId = x.WordId,
                    Text = x.Text,
                })
                .ToArrayAsyncEF(ct);

            return new FlashCardsDto
            {
                Word = nextQuizQuestion.Text,
                FlashCards = flashCards
            };
        }

        public Task<QuestionDto> GetQuestion(Guid userId, CancellationToken ct = default)
        {
            return context.UserQuizQuestions
                .Where(x => x.Quiz.UserId == userId)
                .Where(x => x.Quiz.Status == UserQuizStatus.Active)
                .Where(x => x.Status == UserQuizQuestionStatus.New)
                .OrderBy(x => x.Id)
                .Select(x => new QuestionDto
                {
                    Word = x.Word.Text,
                    CorrectWordId = x.WordId,
                    QuestionId = x.Id,
                    LanguageId = x.Quiz.LanguageId,
                    Translation = context.Translations
                        .Where(y => y.LanguageId == x.Quiz.LanguageId)
                        .First(y => y.WordId == x.WordId)
                        .Text,
                    Transcription = context.Translations
                        .Where(y => y.LanguageId == x.Quiz.LanguageId)
                        .First(y => y.WordId == x.WordId)
                        .Transcription
                })
                .FirstOrThrowNotFoundEFAsync(ct);
        }

        public Task SetQuizQuestionStatus(long questionId, UserQuizQuestionStatus status, CancellationToken ct = default)
        {
            return context.UserQuizQuestions
                .Where(x => x.Id == questionId)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(y => y.Status, status)
                    .SetProperty(y => y.AnsweredAt, dateTimeProvider.UtcNow),
                     ct);
        }

        public Task UpdateTranslationWinStreakAsync(long wordId, long languageId,  Guid userId, bool increase, CancellationToken ct = default)
        {
            return context.LearnedTranslations
                .Merge()
                .Using([new LearnedTranslation { WordId = wordId, LanguageId = languageId, UserId = userId}])
                .On(
                    x => new { x.WordId, x.LanguageId, x.UserId },
                    x => new { x.WordId, x.LanguageId, x.UserId })
                .InsertWhenNotMatched(x => new LearnedTranslation
                {
                    LanguageId = x.LanguageId,
                    WordId = x.WordId,
                    UserId = x.UserId,
                    WinStreakCount = increase ? 1 : 0,
                    LearnedAt =  increase ? x.WinStreakCount == 3 ? dateTimeProvider.UtcNow : null : null,
                })
                .UpdateWhenMatched((o, n) => new LearnedTranslation
                {
                    WinStreakCount = increase ? o.WinStreakCount + 1 : 0,
                    LearnedAt = increase ? o.WinStreakCount == 3 ? dateTimeProvider.UtcNow : null : null,
                })
                .MergeAsync(ct);
        }

        public Task<CurrentQuizStats> GetCurrentQuizStatsAsync(Guid userId, CancellationToken ct = default)
        {
            return context.UserQuizzes
                .Where(q => q.UserId == userId)
                .Where(q => q.Status == UserQuizStatus.Active)
                .Select(x => new CurrentQuizStats
                {
                    TotalQuestions = x.UserQuizQuestions.Count,
                    AnsweredQuestions = x.UserQuizQuestions.Count(y => y.Status != UserQuizQuestionStatus.New),
                    Id = x.Id,
                    LanguageId = x.LanguageId,
                })
                .FirstOrThrowNotFoundEFAsync(ct);
        }

        public Task<LastQuizStats> GetLastQuizStatsAsync(Guid userId, CancellationToken ct = default)
        {
            return context.UserQuizzes
                .Where(q => q.UserId == userId)
                .Where(q => q.Status != UserQuizStatus.Active)
                .OrderByDescending(x => x.FinishedAt)
                .Select(x => new LastQuizStats
                {
                    TotalQuestions = x.UserQuizQuestions.Count,
                    CorrectAnswersCount = x.UserQuizQuestions.Count(y => y.Status == UserQuizQuestionStatus.Correct),
                    SkippedAnswersCount = x.UserQuizQuestions.Count(y => y.Status == UserQuizQuestionStatus.Skipped),
                })
                .FirstOrThrowNotFoundEFAsync(ct);
        }
    }
}