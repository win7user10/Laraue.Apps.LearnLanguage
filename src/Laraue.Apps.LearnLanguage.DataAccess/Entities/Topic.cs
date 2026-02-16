using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class Topic : BaseEntity, IDictionaryEntity
{
    [MaxLength(100)]
    public required string Name { get; init; }
    
    public ICollection<WordTopic> WordTopics { get; set; } = null!;
    
    public ICollection<UserQuizTopic> UserQuizTopics { get; set; } = null!;
}