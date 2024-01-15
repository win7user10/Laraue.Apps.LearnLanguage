using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.Common;

public static class Constants
{
    public static readonly JsonSerializerOptions JsonWebOptions = new(JsonSerializerDefaults.Web);
    public const int PaginationCount = 8;
    public const int WordGroupSize = 50;
    public const int RepeatModeGroupSize = 50;
}