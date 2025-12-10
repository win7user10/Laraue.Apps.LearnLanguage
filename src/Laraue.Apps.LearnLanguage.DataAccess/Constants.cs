using System.Text.Encodings.Web;
using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.DataAccess;

public static class Constants
{
    public static readonly JsonSerializerOptions TranslationFileJsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    
    public const int PaginationCount = 8;
}