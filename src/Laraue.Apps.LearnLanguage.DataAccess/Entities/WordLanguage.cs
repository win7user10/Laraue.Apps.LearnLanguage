using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// All possible languages an english <see cref="Word"/> can be translated.
/// </summary>
public sealed class WordLanguage : BaseEntity, IDictionaryEntity
{
    /// <summary>
    /// The language ISO code.
    /// </summary>
    [MaxLength(2)]
    public string Name { get; init; } = string.Empty;
    
    /// <summary>
    /// The language readable name.
    /// </summary>
    [MaxLength(20)]
    public string Description { get; init; } = string.Empty;
}