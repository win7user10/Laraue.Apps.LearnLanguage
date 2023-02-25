namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Represents all words in the system in english
/// </summary>
public class Word : BaseEntity
{
    /// <summary>
    /// The word, e.g. cat, dog etc.
    /// </summary>
    public string Name { get; set; } = default!;
}