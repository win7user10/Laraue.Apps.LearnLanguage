﻿namespace Laraue.Apps.LearnLanguage.Services;

public static class TelegramRoutes
{
    public const string RepeatWindow = "rw";
    public const string RepeatWindowWordsView = "rww";
    public const string HandleSuggestion = "hs";

    public const string ListGroupsByCefrLevel = "lgcl";
    public const string DetailGroupByCefrLevel = "dgcl";
    
    public const string ListGroupsByFirstLetter = "lgfl";
    public const string DetailGroupByFirstLetter = "dgfl";
    
    public const string ListGroupsByTopic = "lgt";
    public const string DetailGroupByTopic = "dgt";
    
    public const string Stat = "stat";
    public const string Menu = "m";
    public const string DropMessage = "d";
    
    public const string Settings = "s";
    public const string InterfaceLanguageSettings = "s/ils";
    public const string LearnLanguageSettings = "s/lls";
    
    // Commands section
    public const string Start = "/start";
}