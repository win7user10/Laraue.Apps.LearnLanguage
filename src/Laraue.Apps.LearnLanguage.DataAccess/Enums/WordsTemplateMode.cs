namespace Laraue.Apps.LearnLanguage.DataAccess.Enums;

/// <summary>
/// How to show group words.
/// </summary>
[Flags]
public enum WordsTemplateMode
{
    /// <summary>
    /// Show translation with the template "word - translation".
    /// </summary>
    Standard = 0,
    
    /// <summary>
    /// Show only left part of the translation.
    /// </summary>
    HideTranslations = 1,
    
    /// <summary>
    /// Show translation with the template "translation - word"
    /// </summary>
    RevertWordAndTranslation = 2,
}