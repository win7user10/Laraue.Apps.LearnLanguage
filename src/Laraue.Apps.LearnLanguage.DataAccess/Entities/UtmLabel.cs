using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class UtmLabel
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(64)]
    public string Value { get; set; } = string.Empty;
}