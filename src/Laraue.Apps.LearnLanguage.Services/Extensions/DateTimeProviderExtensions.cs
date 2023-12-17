using Laraue.Core.DateTime.Extensions;
using Laraue.Core.DateTime.Services.Abstractions;

namespace Laraue.Apps.LearnLanguage.Services.Extensions;

public static class DateTimeProviderExtensions
{
    public static DateTime Yesterday(this IDateTimeProvider provider, DateTimeKind kind = DateTimeKind.Utc)
    {
        return provider.UtcNow.AddDays(-1).Date.UseKind(kind);
    }
}