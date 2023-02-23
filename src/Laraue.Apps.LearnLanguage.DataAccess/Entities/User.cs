using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Telegram.NET.Authentication.Models;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Application user.
/// </summary>
public class User : TelegramIdentityUser
{
    /// <summary>
    /// How to show word translations for this user. 
    /// </summary>
    public WordsTemplateMode WordsTemplateMode { get; set; }
    
    /// <summary>
    /// Which words should be shown to the user.
    /// </summary>
    public ShowWordsMode ShowWordsMode { get; set; }

    public ICollection<WordGroup> WordGroups { get; set; }
    
    public ICollection<WordTranslationState> WordTranslationStates { get; set; }
}