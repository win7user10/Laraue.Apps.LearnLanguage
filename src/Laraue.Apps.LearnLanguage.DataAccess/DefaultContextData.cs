using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.DataAccess;

public class DefaultContextData
{
    public static string GetJsonFilePath(string fileName)
    {
        var assemblyDirectory = Path.GetDirectoryName(typeof(DatabaseContext).Assembly.Location)!;
        
        return Path.Combine(assemblyDirectory, fileName);
    }

    public static T[] GetJsonData<T>(string fileName)
    {
        using var stream = File.OpenRead(GetJsonFilePath(fileName));
        return  JsonSerializer.Deserialize<T[]>(stream, Constants.JsonWebOptions)!;
    }
    
    public static WordCefrLevel[] CefrLevels =
    [
        new () { Id = 1, Name = "A0" },
        new () { Id = 2, Name = "A1" },
        new () { Id = 3, Name = "A2" },
        new () { Id = 4, Name = "B1" },
        new () { Id = 5, Name = "B2" },
        new () { Id = 6, Name = "C1" },
        new () { Id = 7, Name = "C2" }
    ];

    public static WordLanguage[] WordLanguages = GetJsonData<WordLanguage>("languages.json");
    public static WordTopic[] WordTopics = GetJsonData<WordTopic>("topics.json");
    public static ImportingWord[] Words = GetJsonData<ImportingWord>("translations.json");
}