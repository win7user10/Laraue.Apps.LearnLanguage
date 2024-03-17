using System.Text.Encodings.Web;
using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.Common;

public static class Constants
{
    public static readonly JsonSerializerOptions JsonWebOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    
    public const int PaginationCount = 8;
    public const int RepeatModeGroupSize = 50;
}