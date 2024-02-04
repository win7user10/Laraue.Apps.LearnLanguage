using System.Text;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Resources;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.DataAccess;
using Laraue.Telegram.NET.DataAccess.Extensions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class WordsWindow(
    IFullPaginatedResult<LearningItem> words,
    UserViewSettings userViewSettings,
    RoutePathBuilder viewRoute,
    ITelegramBotClient client,
    IWordsRepository wordsRepository)
    : IWordsWindow
{
    private RoutePathBuilder? _paginationRoute;
    private string _title = "Words";
    private LearningItem? _openedTranslation;
    private InlineKeyboardButton? _backButton;
    private ControlButtons? _fallbackPaginationButtons;
    private IEnumerable<InlineKeyboardButton>? _actionButtons;
    private bool _useFilters;

    public IWordsWindow SetWindowTitle(string title)
    {
        _title = title;
        return this;
    }

    public IWordsWindow SetOpenedTranslation(LearningItem openedTranslation)
    {
        _openedTranslation = openedTranslation;
        return this;
    }

    public IWordsWindow SetPaginationRoute(RoutePathBuilder paginationRoute)
    {
        _paginationRoute = paginationRoute;
        return this;
    }

    public IWordsWindow SetBackButton(InlineKeyboardButton button)
    {
        _backButton = button;
        return this;
    }

    public IWordsWindow SetFallbackPaginationButtons(ControlButtons controlButtons)
    {
        _fallbackPaginationButtons = controlButtons;
        return this;
    }
    
    public IWordsWindow SetActionButtons(IEnumerable<InlineKeyboardButton> actionButtons)
    {
        _actionButtons = actionButtons;
        return this;
    }

    public IWordsWindow UseFilters(bool useFilters = true)
    {
        _useFilters = useFilters;
        return this;
    }

    public async Task SendAsync(ReplyData replyData, CancellationToken ct = default)
    {
        var areTranslationHidden = userViewSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.HideTranslations);
        
        var areTranslationsReverted = userViewSettings
            .WordsTemplateMode
            .HasFlag(WordsTemplateMode.RevertWordAndTranslation);

        viewRoute = viewRoute
            .WithQueryParameter(Defaults.PageParameterName, words.Page)
            .Freeze();
        
        var toggleTranslationsButton = viewRoute
            .WithQueryParameter(ParameterNames.ToggleTranslations, true)
            .ToInlineKeyboardButton(areTranslationHidden ? Mode.ShowTranslations : Mode.HideTranslations);
        
        var reverseTranslationsButton = viewRoute
            .WithQueryParameter(ParameterNames.RevertTranslations, true)
            .ToInlineKeyboardButton(areTranslationsReverted ? Mode.ViewMode_WordToTranslation : Mode.ViewMode_TranslationToWord);

        List<InlineKeyboardButton>? changeShowWordsModeButtons = null; 
        if (_useFilters)
        {
            changeShowWordsModeButtons = new List<InlineKeyboardButton>();
            if (userViewSettings.ShowWordsMode != ShowWordsMode.Hard)
            {
                changeShowWordsModeButtons.Add(viewRoute
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.Hard)
                    .ToInlineKeyboardButton(Mode.Filter_Marked));
            }
        
            if (userViewSettings.ShowWordsMode != ShowWordsMode.NotLearned)
            {
                changeShowWordsModeButtons.Add(viewRoute
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.NotLearned)
                    .ToInlineKeyboardButton(Mode.Filter_NotLearned));
            }
        
            if (userViewSettings.ShowWordsMode != ShowWordsMode.All)
            {
                changeShowWordsModeButtons.Add(viewRoute
                    .WithQueryParameter(ParameterNames.ShowMode, ShowWordsMode.All)
                    .ToInlineKeyboardButton(Mode.Filter_None));
            }
        }
        
        var tmb = new TelegramMessageBuilder()
            .AppendRow($"<b>{_title}. {Mode.Page} {words.Page + 1}/{words.LastPage + 1}</b>")
            .AppendRow()
            .AppendDataRows(words, (x, i) =>
            {
                var msgBuilder = GetTextBuilder(x, areTranslationsReverted, areTranslationHidden);
                msgBuilder.Insert(0, ") ")
                    .Insert(0, x.SerialNumber);

                var difficultyString = CommonStrings.GetDifficultyString(x.Difficulty, x.CefrLevel);
                if (difficultyString is not null)
                {
                    msgBuilder.Append($" <b>({difficultyString})</b> ");
                }
                
                if (x.LearnedAt != null)
                {
                    msgBuilder.Append('✅');
                }

                if (x.IsMarked)
                {
                    msgBuilder.Append("🧠");
                }

                return msgBuilder.ToString();
            })
            .AppendRow();
        
        if (_openedTranslation is null)
        {
            tmb.AppendRow(Mode.OpenWord);
        }
        else
        {
            tmb.AppendRow(Mode.OpenedWord)
                .AppendRow(GetTextBuilder(_openedTranslation, false, false).ToString());

            tmb.AppendRow();
            
            if (_openedTranslation.Topic is not null)
            {
                tmb.AppendRow(string.Format(Mode.Topic, _openedTranslation.Topic));
            }

            if (_openedTranslation.Difficulty is not null || _openedTranslation.CefrLevel is not null)
            {
                tmb.AppendRow(
                    string.Format(
                        Mode.Difficulty,
                        CommonStrings.GetDifficultyString(_openedTranslation.Difficulty, _openedTranslation.CefrLevel)));
            }
                
            if (_openedTranslation.LearnedAt is not null)
            {
                var daysLearnedAgo = (DateTime.UtcNow - _openedTranslation.LearnedAt.Value).TotalDays;
                tmb.AppendRow(string.Format(Mode.Learned, $"{daysLearnedAgo:N0}"));
            }
                
            if (_openedTranslation.RepeatedAt is not null)
            {
                var daysRepeatedAgo = (DateTime.UtcNow - _openedTranslation.RepeatedAt.Value).TotalDays;
                tmb.AppendRow(string.Format(Mode.Repeated, $"{daysRepeatedAgo:N0}"));
            }
        }
        
        tmb
            .AddInlineKeyboardButtons(words, (x, _) => viewRoute
                .WithQueryParameter(ParameterNames.OpenedTranslationId, x.TranslationId)
                .ToInlineKeyboardButton(x.SerialNumber.ToString()));

        if (_actionButtons is not null)
        {
            tmb.AddInlineKeyboardButtons(_actionButtons);
        }
        
        tmb.AddPaginationButtons(
            words,
            _paginationRoute ?? viewRoute,
            fallbackButtons: _fallbackPaginationButtons,
            previousButtonText: Mode.Navigation_Previous,
            nextButtonText: Mode.Navigation_Next);
        
        tmb
            .AddInlineKeyboardButtons(new []{ toggleTranslationsButton, reverseTranslationsButton });

        if (changeShowWordsModeButtons is not null)
        {
            tmb.AddInlineKeyboardButtons(changeShowWordsModeButtons);
        }
        
        if (_backButton is not null)
        {
            tmb.AddInlineKeyboardButtons(new[] { _backButton });
        }

        await client.EditMessageTextAsync(
            replyData,
            tmb,
            ParseMode.Html,
            cancellationToken: ct);
        
        await wordsRepository.IncrementLearnAttemptsIfRequiredAsync(
            replyData.UserId,
            words.Data
                .Select(x => x.TranslationId)
                .ToArray(),
            ct);
    }

    private static StringBuilder GetTextBuilder(
        LearningItem item,
        bool areTranslationsReverted,
        bool areTranslationHidden)
    {
        (string, string?) textParts = new ()
        {
            Item1 = areTranslationsReverted ? item.Translation : item.Word,
            Item2 = areTranslationHidden
                ? null
                : areTranslationsReverted
                    ? item.Word
                    : item.Translation
        };

        if (areTranslationHidden)
        {
            textParts.Item2 = null;
        }
            
        var msgBuilder = new StringBuilder()
            .Append(textParts.Item1);

        if (textParts.Item2 is not null)
        {
            msgBuilder.Append('-')
                .Append(textParts.Item2);
        }

        return msgBuilder;
    }
}