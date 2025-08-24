using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;
using Telegram.Bot;
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
    public async Task HandleQuizWindowAsync(ReplyData replyData, OpenModeRequest request, CancellationToken ct = default)
    {
        var hasActiveQuiz = await repository.HasActiveQuizAsync(replyData.UserId, ct);
        var task = hasActiveQuiz
            ? HandleCurrentQuizWindowAsync(replyData, ct)
            : HandleNewQuizWindowAsync(replyData, request, ct);

        await task;
    }

    private async Task HandleNewQuizWindowAsync(ReplyData replyData, OpenModeRequest request, CancellationToken ct = default)
    {
        await selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
            request,
            "Quiz mode",
            TelegramRoutes.QuizSetup,
            replyData,
            StartNewQuizAsync,
            ct);
    }
    
    private async Task StartNewQuizAsync(
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);
        
        var quizId = await repository.CreateQuizAsync(
            replyData.UserId,
            selectedTranslation.LanguageToLearnFromId!.Value,
            ct);

        // TODO - use settings to setup
        const int questionsCount = 20;
        const int optionsCount = 6;
        
        var questions = await questionsGenerator.GenerateQuestions(
            replyData.UserId,
            selectedTranslation.LanguageToLearnFromId!.Value,
            questionsCount,
            optionsCount,
            ct);

        await repository.SaveQuizQuestionsAsync(quizId, questions, ct);
        
        await transaction.CommitAsync(ct);
        
        await HandleCurrentQuizWindowAsync(replyData, ct);
    }
    
    private async Task HandleCurrentQuizWindowAsync(
        ReplyData replyData,
        CancellationToken ct = default)
    {
        
    }

    public interface IRepository
    {
        Task<bool> HasActiveQuizAsync(Guid userId, CancellationToken ct = default);
        Task<long> CreateQuizAsync(Guid userId, long languageId, CancellationToken ct = default);
        Task SaveQuizQuestionsAsync(long quizId, QuestionDto[] questions, CancellationToken ct = default);
        Task<FlashCard[]> GetFlashCardsAsync(CancellationToken ct = default);
    }

    public class FlashCard
    {
        public required long TranslationId { get; set; }
        public required string Text { get; set; }
    }

    public class CurrentQuizState
    {
        public UserQuizStatus? Status { get; set; }
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

        public async Task SaveQuizQuestionsAsync(
            long quizId,
            QuestionDto[] questions,
            CancellationToken ct = default)
        {
            foreach (var question in questions)
            {
                var entity = new UserQuizQuestion
                {
                    TranslationId = question.WordId,
                    Status = UserQuizQuestionStatus.New,
                    QuizId = quizId,
                    OptionIds = question.OptionIds,
                };
                
                context.UserQuizQuestions.Add(entity);
            }

            await context.SaveChangesAsync(ct);
        }

        public Task<FlashCard[]> GetFlashCardsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}