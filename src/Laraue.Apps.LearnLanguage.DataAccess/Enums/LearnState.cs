namespace Laraue.Apps.LearnLanguage.DataAccess.Enums;

[Flags]
public enum LearnState : byte
{
    /// <summary>
    /// Word not marked
    /// </summary>
    None = 0,
    
    /// <summary>
    /// Word has been learned already
    /// </summary>
    Learned = 1,
    
    /// <summary>
    /// This word has been marked as hard to learn
    /// </summary>
    Hard = 2,
}