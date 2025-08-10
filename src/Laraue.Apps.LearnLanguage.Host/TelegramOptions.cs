using Laraue.Telegram.NET.Authentication.Services;
using Laraue.Telegram.NET.Core;

namespace Laraue.Apps.LearnLanguage.Host;

public class TelegramOptions : TelegramNetOptions
{
    public required RoleUsers UserNamesByRoles { get; set; }
}