namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// All possible languages an english <see cref="Word"/> can be translated.
/// </summary>
public class TranslationLanguage : BaseEntity
{
    /// <summary>
    /// The language code.
    /// </summary>
    public string Code { get; init; } = default!;
}