using Laraue.Apps.LearnLanguage.AppServices.Extensions;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
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

namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public class QuizService(
    QuizService.IRepository repository,
    ISelectLanguageService selectLanguageService,
    ITelegramBotClient client,
    DatabaseContext context,
    IQuestionsGenerator questionsGenerator)
    : IQuizService
{
    private const long NullOptionId = 0;
    private const int WinStreakToLearn = 3;
    private const int MaxTopicsCount = 30;
    
    // TODO - use settings to setup
    private const int QuestionsCount = 20;
    private const int OptionsCount = 8;
    
    /// <summary>
    /// Handle any request related to quiz. If quiz is started handle answers, otherwise handle new quiz window.
    /// </summary>
    public async Task OpenQuizWindowAsync(
        ReplyData replyData,
        QuizRequest request,
        CancellationToken ct = default)
    {
        var hasActiveQuiz = await HasActiveQuizAsync(replyData.UserId, ct);
        
        var task = hasActiveQuiz
            ? OpenNextQuizQuestionWindowAsync(
                replyData,
                previousAnswerResult: null,
                ct)
            : OpenNewQuizWindowAsync(
                replyData,
                request,
                ct);

        await task;
    }

    private Task<bool> HasActiveQuizAsync(Guid userId, CancellationToken ct)
    {
        return repository.HasActiveQuizAsync(userId, ct);
    }

    /// <summary>
    /// Before start a new quiz ask user to select language pair for this quiz (or take it from settings if set).
    /// </summary>
    private Task OpenNewQuizWindowAsync(
        ReplyData replyData,
        QuizRequest request,
        CancellationToken ct = default)
    {
        return selectLanguageService.ShowLanguageWindowOrHandleRequestAsync(
            request,
            QuizMode.ButtonName,
            TelegramRoutes.CurrentQuiz,
            replyData,
            OpenBeforeQuizStartWindowAsync,
            ct);
    }

    /// <summary>
    /// Draw a window from which the quiz can be launched or options can be changed.
    /// </summary>
    private async Task OpenBeforeQuizStartWindowAsync(
        QuizRequest request,
        ReplyData replyData,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder();
        
        var topic = await repository.GetUserQuizTopicAsync(replyData.UserId, ct);
        var languageCode = await repository.GetLanguageCodeAsync(
            selectedTranslation.LanguageToLearnId!.Value,
            ct);

        var questionsCount = topic?.WordsCount ?? await repository.GetQuestionsCountByFilterAsync(
            selectedTranslation.LanguageToLearnId!.Value,
            topic?.Id,
            ct);

        var learnStat = await repository.GetLearnStatAsync(
            replyData.UserId,
            selectedTranslation.LanguageToLearnId!.Value,
            topic?.Id,
            ct);

        var topicName = topic?.Name ?? "Not Set";

        tmb
            .AppendRow($"<b>{QuizMode.QuizReady}</b>")
            .AppendRow()
            .AppendRow($"{QuizMode.Topic}: <b>{topicName}</b>")
            .AppendRow($"{QuizMode.QuestionsWillBeAsked}: <b>{QuestionsCount}</b>")
            .AppendRow($"{QuizMode.TotalQuestionsByCriteria}: <b>{questionsCount}</b>")
            .AppendRow($"{QuizMode.LanguagePair}: <b>en -> {languageCode}</b>")
            .AppendRow($"{QuizMode.QuestionOptionsCount}: <b>{OptionsCount}</b>")
            .AppendRow()
            .AppendRow($"<b>{QuizMode.StatsForTheCurrentCriteria}:</b>");
        
        foreach (var winStreak in learnStat.WinStreaks)
        {
            tmb.AppendRow($"{QuizMode.WinStreak} ({winStreak.Key}): {winStreak.Value}");
        }

        tmb.AppendRow(
            $"{QuizMode.Learned}: {learnStat.Learned} / {learnStat.Total}");
            
        tmb
            .AddInlineKeyboardButtons([InlineKeyboardButton.WithCallbackData(
                QuizMode.StartButtonName,
                new CallbackRoutePath(TelegramRoutes.StartQuiz, RouteMethod.Post)
                    .WithTranslationDirection(selectedTranslation))])
            .AddInlineKeyboardButtons([InlineKeyboardButton.WithCallbackData(
                QuizMode.ChangeTopic,
                new CallbackRoutePath(TelegramRoutes.TopicSelection)
                    .WithTranslationDirection(selectedTranslation))]);
        
        // Add back button only when language pair setup is available
        var isDefaultLanguagePairSet = await repository.DoesUserSetDefaultLanguagePairAsync(replyData.UserId, ct);
        if (!isDefaultLanguagePairSet)
        {
            tmb.AddInlineKeyboardButtons([
                InlineKeyboardButton.WithCallbackData(
                    QuizMode.ChangeLanguagePair,
                    TelegramRoutes.CurrentQuiz)
            ]);
        }
        
        tmb.AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task ChangeTopicAsync(
        ReplyData replyData,
        ChangeTopicRequest request,
        CancellationToken ct = default)
    {
        long? optionId = request.TopicId == NullOptionId ? null : request.TopicId;
        await repository.UpdateTopicAsync(replyData.UserId, optionId, ct);

        await OpenNewQuizWindowAsync(
            replyData,
            new QuizRequest { LanguageToLearnId = request.LanguageToLearnId },
            ct);
    }

    public async Task OpenSelectTopicWindowAsync(
        ReplyData replyData,
        SelectTopicRequest request,
        CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(QuizMode.SelectQuizTopic);
        
        var topics = await repository.GetTopicsAsync(MaxTopicsCount, ct);
        foreach (var chunkedTopics in topics.Chunk(2))
        {
            tmb.AddInlineKeyboardButtons(chunkedTopics
                .Select(topic => new CallbackRoutePath(TelegramRoutes.TopicSelection, RouteMethod.Post)
                    .WithQueryParameter(ParameterNames.TopicId, topic.Id)
                    .WithTranslationDirection(request)
                    .ToInlineKeyboardButton($"{topic.Name} ({topic.WordsCount})")));
        }

        tmb
            .AddInlineKeyboardButtons([new CallbackRoutePath(TelegramRoutes.TopicSelection, RouteMethod.Post)
                .WithQueryParameter(ParameterNames.TopicId, NullOptionId)
                .WithTranslationDirection(request)
                .ToInlineKeyboardButton(Settings.NotSet)])
            .AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    /// <summary>
    /// The start quiz logic.
    /// </summary>
    public async Task StartNewQuizAsync(
        ReplyData replyData,
        StartQuizRequest startQuizRequest,
        CancellationToken ct = default)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);

        var topicData = await repository.GetUserQuizTopicAsync(replyData.UserId, ct);
        var quizId = await repository.CreateQuizAsync(
            replyData.UserId,
            startQuizRequest.LanguageToLearnId!.Value,
            topicData?.Id,
            ct);
        
        var questions = await questionsGenerator.GenerateQuestions(
            replyData.UserId,
            startQuizRequest.LanguageToLearnId!.Value,
            topicData?.Id,
            QuestionsCount,
            OptionsCount,
            ct);

        await repository.SaveQuizQuestionsAsync(quizId, questions, ct);
        
        await transaction.CommitAsync(ct);
        
        await OpenNextQuizQuestionWindowAsync(
            replyData,
            previousAnswerResult: null,
            ct);
    }

    public async Task FinishQuizAsync(ReplyData replyData, CancellationToken ct = default)
    {
        await repository.SkipAllQuizQuestions(replyData.UserId, ct);

        await OpenNextQuizQuestionWindowAsync(
            replyData,
            previousAnswerResult: null,
            ct);
    }
    
    public async Task SelectQuizAnswerAsync(
        ReplyData replyData,
        SelectQuizAnswerRequest request,
        CancellationToken ct = default)
    {
        var result = await HandleSelectedOptionAsync(
            replyData.UserId,
            request.SelectedOptionId,
            ct);

        await OpenNextQuizQuestionWindowAsync(
            replyData,
            result,
            ct);
    }

    private async Task OpenNextQuizQuestionWindowAsync(
        ReplyData replyData,
        HandleSelectedOptionResponse? previousAnswerResult,
        CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder();

        if (previousAnswerResult != null)
        {
            tmb
                .Append(QuizMode.ResourceManager.GetString($"QuizAnswer_{previousAnswerResult.Status}") ?? string.Empty)
                .Append(" ")
                .Append(previousAnswerResult.QuestionDto.Word)
                .Append(" ")
                .Append(previousAnswerResult.QuestionDto.Translation)
                .AppendRow($" [{previousAnswerResult.QuestionDto.Transcription}]")
                .AppendRow();
        }
        
        
        var stats = await repository.GetCurrentQuizStatsAsync(replyData.UserId, ct);
        if (stats.AnsweredQuestions == stats.TotalQuestions)
        {
            await HandleFinishQuizAsync(replyData, stats.Id, stats.LanguageId, ct);
            return;
        }
        
        var data = await repository.GetFlashCardsAsync(stats.Id, stats.LanguageId, ct);

        tmb
            .Append(QuizMode.Question)
            .AppendRow($" <b>{stats.AnsweredQuestions + 1}/{stats.TotalQuestions}</b>")
            .Append(QuizMode.TranslateWord)
            .AppendRow($" <b>{data.Word}</b> ({data.PartOfSpeech})");

        foreach (var flashCardsChunk in data.FlashCards.Chunk(2))
        {
            tmb.AddInlineKeyboardButtons(flashCardsChunk
                .Select(x => InlineKeyboardButton.WithCallbackData(
                    System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.Text),
                    new CallbackRoutePath(TelegramRoutes.SelectQuizAnswer, RouteMethod.Post)
                        .WithQueryParameter(ParameterNames.OpenedWordId, x.WordId))));
        }

        tmb.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(
                QuizMode.SkipButtonName,
                new CallbackRoutePath(TelegramRoutes.SelectQuizAnswer, RouteMethod.Post)
                    .WithQueryParameter(ParameterNames.OpenedWordId, NullOptionId))
        ]);
        
        tmb.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(
                QuizMode.FinishQuiz,
                new CallbackRoutePath(TelegramRoutes.FinishQuiz, RouteMethod.Post))
        ]);
        
        tmb.AddMainMenuButton();

        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    private async Task HandleFinishQuizAsync(
        ReplyData replyData,
        long quizId,
        long languageId,
        CancellationToken ct = default)
    {
        await repository.SetQuizFinished(quizId, ct);
        var learnStat = await repository.GetLearnStatAsync(replyData.UserId, languageId, null, ct);
        
        var lastQuizQuestions = await repository.GetLastQuizQuestionsAsync(replyData.UserId, ct);
        var correctCount = lastQuizQuestions.Count(q => q.Status == UserQuizQuestionStatus.Correct);
        var skippedCount = lastQuizQuestions.Count(q => q.Status == UserQuizQuestionStatus.Skipped);
        var incorrectCount = lastQuizQuestions.Length - correctCount - skippedCount;

        var tmb = new TelegramMessageBuilder()
            .AppendRow(QuizMode.QuizFinishedTitle)
            .AppendRow();

        for (var index = 0; index < lastQuizQuestions.Length; index++)
        {
            var lastQuizQuestion = lastQuizQuestions[index];
            tmb
                .Append($"{index + 1:00}")
                .Append(". ")
                .Append("<b>")
                .Append(QuizMode.ResourceManager.GetString($"QuizAnswer_{lastQuizQuestion.Status}") ?? string.Empty)
                .Append(" ")
                .Append(lastQuizQuestion.Word)
                .Append("</b>")
                .Append(" ")
                .Append(lastQuizQuestion.Translation);

            if (lastQuizQuestion.Transcription is not null)
            {
                tmb.Append(" [")
                    .Append(lastQuizQuestion.Transcription)
                    .Append("]");
            }

            tmb.AppendRow();
        }

        tmb.AppendRow();

        if (correctCount == lastQuizQuestions.Length)
        {
            tmb.AppendRow($"<b>{QuizMode.Perfect}</b>");
        }
        
        tmb
            .Append(QuizMode.Correct)
            .Append(" - ")
            .AppendRow(correctCount.ToString())
            .Append(QuizMode.Skipped)
            .Append(" - ")
            .AppendRow(skippedCount.ToString())
            .Append(QuizMode.Incorrect)
            .Append(" - ")
            .AppendRow(incorrectCount.ToString());

        var learnedInSessionCount = lastQuizQuestions
            .Where(q => q.Status == UserQuizQuestionStatus.Correct)
            .Count(q => q.LearnedAttempts == WinStreakToLearn);
        
        tmb
            .AppendRow()
            .AppendRow($"<b>{QuizMode.TotalStat}</b>:");

        foreach (var winStreak in learnStat.WinStreaks)
        {
            var newWinStrikesCount = lastQuizQuestions
                .Where(q => q.Status == UserQuizQuestionStatus.Correct)
                .Count(q => q.LearnedAttempts == winStreak.Key);
            
            tmb.AppendRow($"{QuizMode.WinStreak} ({winStreak.Key}): {winStreak.Value} [+{newWinStrikesCount}]");
        }
        
        tmb
            .AppendRow($"{QuizMode.Learned}: {learnStat.Learned} / {learnStat.Total} [+{learnedInSessionCount}]")
            .AddInlineKeyboardButtons([
                InlineKeyboardButton.WithCallbackData(
                    Buttons.RepeatQuiz,
                    new CallbackRoutePath(TelegramRoutes.StartQuiz, RouteMethod.Post)
                        .WithTranslationDirection(new SelectedTranslation(languageId)))
            ])
            .AddMainMenuButton();
        
        await client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    /// <returns>True if request handled and processing should be stopped.</returns>
    private async Task<HandleSelectedOptionResponse> HandleSelectedOptionAsync(
        Guid userId,
        long selectedOptionId,
        CancellationToken ct = default)
    {
        var question = await repository.GetQuestion(userId, ct);

        var status = selectedOptionId == NullOptionId
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

    public class HandleSelectedOptionResponse
    {
        public required UserQuizQuestionStatus Status { get; set; }
        public required QuestionDto QuestionDto { get; set; }
    }

    public interface IRepository
    {
        Task<bool> HasActiveQuizAsync(Guid userId, CancellationToken ct = default);
        Task<long> CreateQuizAsync(Guid userId, long languageId, long? topicId, CancellationToken ct = default);
        Task SetQuizFinished(long quizId, CancellationToken ct = default);
        Task SaveQuizQuestionsAsync(long quizId, NewQuestionDto[] questions, CancellationToken ct = default);
        Task SkipAllQuizQuestions(Guid userId, CancellationToken ct = default);
        Task<FlashCardsDto> GetFlashCardsAsync(long quizId, long languageId, CancellationToken ct = default);
        Task<QuestionDto> GetQuestion(Guid userId, CancellationToken ct = default);
        Task SetQuizQuestionStatus(long questionId, UserQuizQuestionStatus status, CancellationToken ct = default);
        Task UpdateTranslationWinStreakAsync(long wordId, long languageId, Guid userId, bool increase, CancellationToken ct = default);
        Task<CurrentQuizStats> GetCurrentQuizStatsAsync(Guid userId, CancellationToken ct = default);
        Task<LastQuizStatsQuestion[]> GetLastQuizQuestionsAsync(Guid userId, CancellationToken ct = default);
        Task<LearnStat> GetLearnStatAsync(Guid userId, long languageId, long? topicId, CancellationToken ct = default);
        Task<string?> GetLanguageCodeAsync(long languageId, CancellationToken ct = default);
        Task<TopicItemDto?> GetUserQuizTopicAsync(Guid userId, CancellationToken ct = default);
        Task<int> GetQuestionsCountByFilterAsync(long languageId, long? topicId, CancellationToken ct = default);
        Task<TopicItemDto[]> GetTopicsAsync(int count, CancellationToken ct = default);
        Task UpdateTopicAsync(Guid userId, long? topicId, CancellationToken ct = default);
        Task<bool> DoesUserSetDefaultLanguagePairAsync(Guid userId, CancellationToken ct = default);
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

    public class LastQuizStatsQuestion
    {
        public required string Word { get; init; }
        public required string Translation { get; init; }
        public required string? Transcription { get; init; }
        public required UserQuizQuestionStatus Status { get; init; }
        public required int LearnedAttempts { get; init; }
    }
    
    public class LearnStat
    {
        public required int Learned { get; init; }
        public required Dictionary<int, int> WinStreaks { get; init; }
        public required int Total { get; init; }
    }
    
    public class FlashCardsDto
    {
        public required string Word { get; set; }
        public required string PartOfSpeech { get; set; }
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

    public class TopicItemDto
    {
        public long Id { get; init; }
        public int WordsCount { get; init; }
        public required string Name { get; init; }
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

        public async Task<long> CreateQuizAsync(Guid userId, long languageId, long? topicId, CancellationToken ct = default)
        {
            var quiz = new UserQuiz
            {
                UserId = userId,
                Status = UserQuizStatus.Active,
                CreatedAt = dateTimeProvider.UtcNow,
                LanguageId = languageId,
                TopicId = topicId,
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
                    x.Word.Text,
                    PartOfSpeech = x.Word.PartOfSpeech!.Name,
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
                FlashCards = flashCards,
                PartOfSpeech = nextQuizQuestion.PartOfSpeech,
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
                    Transcription = x.Word.Transcription,
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
                    LearnedAt =  increase ? x.WinStreakCount + 1 >= WinStreakToLearn ? dateTimeProvider.UtcNow : null : null,
                })
                .UpdateWhenMatched((o, n) => new LearnedTranslation
                {
                    WinStreakCount = increase ? o.WinStreakCount + 1 : 0,
                    LearnedAt = increase ? o.WinStreakCount + 1 >= WinStreakToLearn ? dateTimeProvider.UtcNow : null : null,
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

        public async Task<LastQuizStatsQuestion[]> GetLastQuizQuestionsAsync(Guid userId, CancellationToken ct = default)
        {
            var quiz = await context.UserQuizzes
                .Where(q => q.UserId == userId)
                .Where(q => q.Status != UserQuizStatus.Active)
                .OrderByDescending(x => x.FinishedAt)
                .Select(x => new { x.Id })
                .FirstOrDefaultAsyncEF(ct);

            if (quiz == null)
            {
                return [];
            }
            
            return await context.UserQuizQuestions
                .Where(x => x.QuizId == quiz.Id)
                .OrderBy(x => x.Id)
                .Select(x => new LastQuizStatsQuestion
                {
                    Status = x.Status,
                    Word = x.Word.Text,
                    Translation = context.Translations
                        .Where(y => y.LanguageId == x.Quiz.LanguageId)
                        .First(y => y.WordId == x.WordId)
                        .Text,
                    Transcription = context.Translations
                        .Where(y => y.LanguageId == x.Quiz.LanguageId)
                        .First(y => y.WordId == x.WordId)
                        .Transcription,
                    LearnedAttempts = context.LearnedTranslations
                        .Where(t => t.LanguageId == x.Quiz.LanguageId)
                        .Where(t => t.UserId == x.Quiz.UserId)
                        .Where(t => t.WordId == x.WordId)
                        .Select(t => t.WinStreakCount)
                        .FirstOrDefault()
                })
                .ToArrayAsyncEF(ct);
        }

        public async Task<LearnStat> GetLearnStatAsync(Guid userId, long languageId, long? topicId, CancellationToken ct = default)
        {
            var query = context.LearnedTranslations
                .Where(q => q.UserId == userId)
                .Where(q => q.LanguageId == languageId);
            
            if (topicId.HasValue)
                query = query.Where(tr => tr.Word.Topics.Any(t => t.TopicId == topicId.Value));
            
            var learnedCount = await query
                .CountAsyncEF(x => x.LearnedAt != null, ct);

            var allWinStreaksRows = Enumerable.Range(1, WinStreakToLearn - 1);
            var winStreaksInDb = await query
                .Where(x => x.WinStreakCount > 0 && x.WinStreakCount < WinStreakToLearn)
                .GroupBy(x => x.WinStreakCount)
                .ToDictionaryAsyncEF(x => x.Key, x => x.Count(), ct);

            var winStreaks = allWinStreaksRows
                .ToDictionary(x => x, x => winStreaksInDb.GetValueOrDefault(x));
            
            var totalCountQuery = context.Translations
                .Where(x => x.LanguageId == languageId);
            
            if (topicId.HasValue)
                totalCountQuery = totalCountQuery
                    .Where(tr => tr.Word.Topics.Any(t => t.TopicId == topicId.Value));

            var totalCount = await totalCountQuery.CountAsyncEF(ct);

            return new LearnStat
            {
                Learned = learnedCount,
                Total = totalCount,
                WinStreaks = winStreaks
            };
        }

        public Task<string?> GetLanguageCodeAsync(long languageId, CancellationToken ct = default)
        {
            return context.Languages
                .Where(x => x.Id == languageId)
                .Select(x => x.Name)
                .FirstOrDefaultAsyncEF(ct);
        }

        public Task<TopicItemDto?> GetUserQuizTopicAsync(Guid userId, CancellationToken ct = default)
        {
            return context.Users
                .Where(u => u.Id == userId)
                .Where(u => u.QuizTopicId.HasValue)
                .Select(u => new TopicItemDto
                {
                    Name = u.QuizTopic.Name,
                    Id = u.QuizTopicId!.Value,
                    WordsCount = u.QuizTopic.WordTopics.Count
                })
                .FirstOrDefaultAsyncEF(ct);
        }

        public Task<int> GetQuestionsCountByFilterAsync(long languageId, long? topicId, CancellationToken ct = default)
        {
            var query = context.Translations
                .Where(x => x.LanguageId == languageId);

            if (topicId.HasValue)
            {
                query = query.Where(x => x.Word.Topics.Any(t => t.TopicId == topicId));
            }
            
            return query.CountAsyncEF(ct);
        }

        public async Task<TopicItemDto[]> GetTopicsAsync(int count, CancellationToken ct = default)
        {
            var topics = await context.Topics
                .Select(topic => new TopicItemDto
                {
                    Id = topic.Id,
                    WordsCount = topic.WordTopics.Count,
                    Name = topic.Name
                })
                .OrderByDescending(x => x.WordsCount)
                .Take(count)
                .ToArrayAsyncEF(ct);

            return topics
                .OrderBy(x => x.Name)
                .ToArray();
        }

        public Task UpdateTopicAsync(Guid userId, long? topicId, CancellationToken ct = default)
        {
            return context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(
                    u => u
                        .SetProperty(p => p.QuizTopicId, topicId),
                    ct);
        }

        public Task<bool> DoesUserSetDefaultLanguagePairAsync(Guid userId, CancellationToken ct = default)
        {
            return context.Users
                .Where(u => u.Id == userId)
                .AnyAsyncEF(u => u.LanguageToLearnId != null, ct);
        }
    }
}