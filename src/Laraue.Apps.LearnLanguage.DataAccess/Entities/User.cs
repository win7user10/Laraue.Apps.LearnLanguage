using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Telegram.NET.Authentication.Models;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class User : TelegramIdentityUser
{
    public WordsTemplateMode WordsTemplateMode { get; set; }
    
    public ShowWordsMode ShowWordsMode { get; set; }
}