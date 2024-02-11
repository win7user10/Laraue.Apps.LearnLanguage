using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class WordCefrLevel : BaseEntity
{
    [MaxLength(2)]
    public required string Name { get; init; }
}