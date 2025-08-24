using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class QuizService(
    QuizService.IRepository repository,
    ISelectLanguageService selectLanguageService,
    ITelegramBotClient client)
    : IQuizService
{
    public async Task HandleQuizWindowAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var state = await repository.GetCurrentQuizStateAsync(replyData.UserId, ct);
        var task = state.Status == null
            ? HandleNewQuizWindowAsync(replyData, ct)
            : HandleCurrentQuizWindowAsync(replyData, ct);

        await task;
    }

    public async Task HandleStartQuizAsync(ReplyData replyData, OpenModeRequest request, CancellationToken ct = default)
    {
        await selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
            request,
            "Quiz language",
            TelegramRoutes.CurrentQuiz,
            replyData,
            StartNewQuizAsync,
            ct);
    }

    private async Task HandleNewQuizWindowAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder();
        
        tmb
            .Append(QuizMode.Description)
            .AddInlineKeyboardButtons(new List<InlineKeyboardButton>
            {
                InlineKeyboardButton
                    .WithCallbackData(QuizMode.StartButtonName, TelegramRoutes.StartQuiz)
            })
            .AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, cancellationToken: ct);
    }
    
    private async Task StartNewQuizAsync(
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        await repository.CreateQuizAsync(replyData.UserId, selectedTranslation, ct);
        await HandleCurrentQuizWindowAsync(replyData, ct);
    }
    
    private async Task HandleCurrentQuizWindowAsync(
        ReplyData replyData,
        CancellationToken ct = default)
    {
        
    }

    public interface IRepository
    {
        Task<CurrentQuizState> GetCurrentQuizStateAsync(Guid userId, CancellationToken ct = default);
        Task CreateQuizAsync(Guid userId, SelectedTranslation selectedTranslation, CancellationToken ct = default);
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
    
    public class Repository : IRepository
    {
        public Task<CurrentQuizState> GetCurrentQuizStateAsync(Guid userId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task CreateQuizAsync(Guid userId, SelectedTranslation selectedTranslation, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<FlashCard[]> GetFlashCardsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}