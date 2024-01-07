using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.Common;

public static class Constants
{
    public static readonly JsonSerializerOptions JsonWebOptions = new(JsonSerializerDefaults.Web);
}