using Laraue.Apps.LearnLanguage.AppServices.Extensions;
using Laraue.Apps.LearnLanguage.AppServices.Options;
using Laraue.Apps.LearnLanguage.AppServices.Resources;
using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public class MenuService(
    ITelegramBotClient client,
    DatabaseContext databaseContext,
    ISelectLanguageService selectLanguageService,
    IQuizService quizService)
    : IMenuService
{
    private const string ReleaseNotesUrl = "https://github.com/win7user10/Laraue.Apps.LearnLanguage/releases";
    
    public Task SendMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{QuizMode.ButtonName}</b> - {QuizMode.Description}")
            .AppendRow()
            .AppendRow($"<b>{Mode.ListMode}</b> - {Mode.ListModeDescription}")
            .AddInlineKeyboardButtons([
                InlineKeyboardButton.WithCallbackData(
                    QuizMode.ButtonName, TelegramRoutes.CurrentQuiz),
                InlineKeyboardButton.WithCallbackData(
                    Mode.ListMode, TelegramRoutes.ViewWordsListMenu)
            ])
            .AddInlineKeyboardButtons([
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Stat, TelegramRoutes.Stat)
            ])
            .AddInlineKeyboardButtons([
                InlineKeyboardButton.WithCallbackData(
                    Buttons.Settings, TelegramRoutes.Settings)
            ])
            .AddInlineKeyboardButtons([
                InlineKeyboardButton.WithUrl(
                    Buttons.ReleaseNotes, ReleaseNotesUrl)
            ]);

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public Task SendWordsListsMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.SelectMode)
            .AppendRow()
            .AppendRow($"<b>{GroupMode.CefrLevel_ButtonName}</b> - {GroupMode.CefrLevel_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Sequential_ButtonName}</b> - {GroupMode.Sequential_Description}")
            .AppendRow()
            .AppendRow($"<b>{GroupMode.Topics_ButtonName}</b> - {GroupMode.Topics_Description}")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.CefrLevel_ButtonName, TelegramRoutes.ListGroupsByCefrLevel),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Topics_ButtonName, TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Sequential_ButtonName, TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddMainMenuButton();

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public async Task StartAsync(
        string rawCommand,
        Guid userId,
        long telegramId,
        CancellationToken ct = default)
    {
        await ProcessUtmLabels(rawCommand, userId, ct);
        
        // Send welcome message
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Menu.Start);

        await selectLanguageService.AppendLanguagePairButtonsAsync(
            tmb,
            new CallbackRoutePath(TelegramRoutes.Start, RouteMethod.Post),
            ct);

        tmb.AddMainMenuButton();

        await client.SendTextMessageAsync(
            telegramId,
            tmb,
            cancellationToken: ct);
    }

    public async Task HandleApplyStartSettingsAsync(
        ApplyStartSettingsRequest request,
        ReplyData replyData,
        CancellationToken ct = default)
    {
        if (request.LanguageToLearnId is not null)
        {
            await databaseContext.Users.Where(u => u.Id == replyData.UserId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.LanguageToLearnId, request.LanguageToLearnId), ct);
        }

        await quizService.OpenQuizWindowAsync(replyData, new QuizRequest(), ct);
    }

    private async Task ProcessUtmLabels(
        string rawCommand,
        Guid userId,
        CancellationToken ct = default)
    {
        var hasUtmLabels = await databaseContext.UtmLabels
            .Where(l => l.UserId == userId)
            .AnyAsync(ct);

        if (hasUtmLabels)
        {
            return;
        }
        
        // Determine utm labels of the user
        var routeRegex = RouteRegexCreator.ForRoute(TelegramRoutes.Start);
        var match = routeRegex.Match(rawCommand);
        if (match.Groups.Count < 2)
        {
            return;
        }
        
        var queryRaw = match.Groups[1].Value;
        if (string.IsNullOrEmpty(queryRaw))
        {
            return;
        }
        
        var queryParts =  queryRaw.Split('_');
        var dbUtmLabels = queryParts
            .Select(part => part.Split('-'))
            .Select(part => new UtmLabel
            {
                Name = part[0].Trim(),
                Value = part.Length > 1 ? part[1].Trim() : string.Empty,
                UserId = userId,
            })
            .ToArray();
                
        databaseContext.UtmLabels.AddRange(dbUtmLabels);
        await databaseContext.SaveChangesAsync(ct);
    }
}