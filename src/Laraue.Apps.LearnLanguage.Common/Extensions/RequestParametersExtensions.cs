using Laraue.Telegram.NET.Core.Request;

namespace Laraue.Apps.LearnLanguage.Common.Extensions;

public static class RequestParametersExtensions
{
    public static int GetPage(this RequestParameters requestParameters)
    {
        var page = requestParameters.GetValueOrDefault<int>(ParameterNames.Page);
        
        return page > 0 ? page : 1;
    }
}