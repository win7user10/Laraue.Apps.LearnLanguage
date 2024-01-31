using System.Text;

namespace Laraue.Apps.LearnLanguage.Common.Extensions;

public static class TimeSpanExtensions
{
    public static string ToReadableString(this TimeSpan timeSpan)
    {
        var sb = new StringBuilder();
        
        if (timeSpan.Days > 0)
        {
            sb.Append($" {Resources.TimeSpanExtensions.days} ")
                .Append(timeSpan.Days);
        }

        sb.Append($" {Resources.TimeSpanExtensions.hours} ")
            .Append(timeSpan.Hours);
        sb.Append($" {Resources.TimeSpanExtensions.minutes} ")
            .Append(timeSpan.Minutes);
        sb.Append($" {Resources.TimeSpanExtensions.seconds} ")
            .Append(timeSpan.Seconds);

        return sb.ToString();
    }
}