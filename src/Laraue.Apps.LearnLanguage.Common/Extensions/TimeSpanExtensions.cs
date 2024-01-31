using System.Globalization;
using System.Text;

namespace Laraue.Apps.LearnLanguage.Common.Extensions;

public static class TimeSpanExtensions
{
    public static string ToReadableString(this TimeSpan timeSpan)
    {
        var sb = new StringBuilder();
        
        if (timeSpan.Days > 0)
        {
            sb.Append(timeSpan.Days)
                .Append($" {Resources.TimeSpanExtensions.day_s_} ");
        }
        
        sb.Append(timeSpan.Hours)
            .Append(" hour(s) ");
        
        sb.Append(timeSpan.Minutes)
            .Append(" minute(s) ");
        
        sb.Append(timeSpan.Seconds)
            .Append(" second(s)");

        return sb.ToString();
    }
}