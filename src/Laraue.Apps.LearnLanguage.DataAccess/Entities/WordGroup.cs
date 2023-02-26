namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Group of words of the user.
/// </summary>
public class WordGroup : BaseEntity
{
    /// <summary>
    /// Internal increment group number for the current user.
    /// </summary>
    public long SerialNumber { get; set; }
    
    /// <summary>
    /// User identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Relation to the user.
    /// </summary>
    public User User { get; set; }
    
    /// <summary>
    /// Relation with words in this words group.
    /// </summary>
    public ICollection<WordGroupWord> WordGroupWords { get; set; }
}