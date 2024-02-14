﻿using Laraue.Apps.LearnLanguage.Common;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public sealed class LearnListRequest
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? languageIdToLearn { get; init; }
    
    [FromQuery(ParameterNames.LanguageToLearnFrom)]
    public long? languageIdToLearnFrom { get; init; }
}