using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class WordTopic : BaseEntity
{
    [MaxLength(100)]
    public required string Name { get; set; }
}