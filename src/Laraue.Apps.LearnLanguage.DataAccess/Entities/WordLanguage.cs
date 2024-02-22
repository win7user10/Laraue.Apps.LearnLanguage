using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// All possible languages an english <see cref="Word"/> can be translated.
/// </summary>
public sealed class WordLanguage : BaseEntity
{
    /// <summary>
    /// The language ISO code.
    /// </summary>
    [MaxLength(2)]
    public string Code { get; init; } = string.Empty;
}