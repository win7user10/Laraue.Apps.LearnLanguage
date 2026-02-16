using System.ComponentModel.DataAnnotations;
using Laraue.Apps.LearnLanguage.Contracts.Enums;
using Laraue.Telegram.NET.Authentication.Models;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

/// <summary>
/// Application user.
/// </summary>
public sealed class User : ITelegramUser<Guid>
{
    /// <inheritdoc />
    public Guid Id { get; init; }
    
    /// <inheritdoc />
    public long TelegramId { get; init; }
    
    /// <inheritdoc />
    [MaxLength(32)]
    public string? TelegramUserName { get; init; }
    
    /// <inheritdoc />
    [MaxLength(2)]
    public string? TelegramLanguageCode { get; init; }
    
    /// <inheritdoc />
    public DateTime CreatedAt { get; init; }
    
    /// <summary>
    /// How to show word translations for this user. 
    /// </summary>
    public WordsTemplateMode WordsTemplateMode { get; set; }
    
    /// <summary>
    /// Which words should be shown to the user.
    /// </summary>
    public ShowWordsMode ShowWordsMode { get; set; }
    
    /// <summary>
    /// The <see cref="WordLanguage"/> reference.
    /// </summary>
    public long? LanguageToLearnId { get; set; }

    /// <summary>
    /// Default language to learn for the user.
    /// </summary>
    public WordLanguage LanguageToLearn { get; set; } = null!;
    
    /// <summary>
    /// CEFR levels set in the settings.
    /// </summary>
    public ICollection<UserQuizCefrLevel> QuizCefrLevels { get; set; } = null!;
    
    /// <summary>
    /// Topics set in the settings.
    /// </summary>
    public ICollection<UserQuizTopic> UserQuizTopics { get; set; } = null!;
}