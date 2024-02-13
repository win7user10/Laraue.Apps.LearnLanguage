using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Telegram.NET.Authentication.Models;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Application user.
/// </summary>
public sealed class User : TelegramIdentityUser<Guid>
{
    /// <summary>
    /// How to show word translations for this user. 
    /// </summary>
    public WordsTemplateMode WordsTemplateMode { get; set; }
    
    /// <summary>
    /// Which words should be shown to the user.
    /// </summary>
    public ShowWordsMode ShowWordsMode { get; set; }
    
    // TODO - store languageId -> languageId that user is learning

    /// <summary>
    /// All user's translation's states.
    /// </summary>
    public ICollection<WordTranslationState> WordTranslationStates { get; set; } = null!;
}