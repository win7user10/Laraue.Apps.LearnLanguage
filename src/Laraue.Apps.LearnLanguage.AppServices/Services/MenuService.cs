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
            .AppendRow(Mode.SelectMode);
        
        AppendMainMenuButtons(tmb);

        return client.EditMessageTextAsync(replyData, tmb, ParseMode.Html, cancellationToken: ct);
    }

    public Task SendWordsListsMenuAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var tmb = new TelegramMessageBuilder()
            .AppendRow(Mode.ListMode)
            .AppendRow($"{Mode.BrowseWords}:")
            .AddInlineKeyboardButtons(new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.CefrLevel_ButtonName, TelegramRoutes.ListGroupsByCefrLevel),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Topics_ButtonName, TelegramRoutes.ListGroupsByTopic),
                InlineKeyboardButton.WithCallbackData(
                    GroupMode.Sequential_ButtonName, TelegramRoutes.ListGroupsByFirstLetter),
            })
            .AddBackMenuButton(TelegramRoutes.Menu);

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
        
        AppendMainMenuButtons(tmb);

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

    private static void AppendMainMenuButtons(TelegramMessageBuilder telegramMessageBuilder)
    {
        telegramMessageBuilder.AddInlineKeyboardButtons([
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
    }
}