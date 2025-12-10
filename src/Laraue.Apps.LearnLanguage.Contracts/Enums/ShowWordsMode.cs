namespace Laraue.Apps.LearnLanguage.Contracts.Enums;

/// <summary>
/// Describe which words will be shown in the group words list.
/// </summary>
public enum ShowWordsMode : byte
{
    /// <summary>
    /// Show all words in the list.
    /// </summary>
    All = 0,
    
    /// <summary>
    /// Show only not learned words in the list.
    /// </summary>
    NotLearned = 2,
}