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

    /// <summary>
    /// All user's translation's states.
    /// </summary>
    public ICollection<TranslationState> WordTranslationStates { get; set; } = null!;
    
    /// <summary>
    /// The <see cref="WordLanguage"/> reference.
    /// </summary>
    public long? LanguageToLearnId { get; set; }

    /// <summary>
    /// Default language to learn for the user.
    /// </summary>
    public WordLanguage LanguageToLearn { get; set; } = null!;

    /// <summary>
    /// The <see cref="WordLanguage"/> reference.
    /// </summary>
    public long? LanguageToLearnFromId { get; set; }

    /// <summary>
    /// Default main language for the user.
    /// </summary>
    public WordLanguage LanguageToLearnFrom { get; set; } = null!;
}