using System.Runtime.CompilerServices;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.Exceptions.Web;

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
    
    public static DictionaryMap<CefrLevel> CefrLevels = new (
    [
        new () { Id = 1, Name = "A0" },
        new () { Id = 2, Name = "A1" },
        new () { Id = 3, Name = "A2" },
        new () { Id = 4, Name = "B1" },
        new () { Id = 5, Name = "B2" },
        new () { Id = 6, Name = "C1" },
        new () { Id = 7, Name = "C2" }
    ]);

    public static DictionaryMap<PartOfSpeech> PartOfSpeeches = new (
    [
        new () { Id = 1, Name = "verb" },
        new () { Id = 2, Name = "noun" },
        new () { Id = 3, Name = "preposition" },
        new () { Id = 4, Name = "adjective" },
        new () { Id = 5, Name = "adverb" },
        new () { Id = 6, Name = "phrase" },
        new () { Id = 7, Name = "determiner" },
        new () { Id = 8, Name = "phrasal verb" },
        new () { Id = 9, Name = "exclamation" },
        new () { Id = 10, Name = "modal verb" },
        new () { Id = 11, Name = "pronoun" },
    ]);

    public static DictionaryMap<WordLanguage> WordLanguages = new (GetJsonData<WordLanguage>("languages.json"));
    public static DictionaryMap<Topic> WordTopics = new (GetJsonData<Topic>("topics.json"));
    public static ImportingWord[] Words = GetJsonData<ImportingWord>("translations.json");

    public sealed class DictionaryMap<TEntity> where TEntity : IDictionaryEntity
    {
        public TEntity[] Items { get; }
        private Dictionary<long, string> ItemsById { get; }
        private Dictionary<string, long> ItemsByCode { get; }

        public DictionaryMap(TEntity[] items)
        {
            Items = items;
            ItemsById = Items.ToDictionary(x => x.Id, x => x.Name);
            ItemsByCode = Items.ToDictionary(x => x.Name, x => x.Id);
        }

        public string GetName(long id, [CallerMemberName] string propertyName = "")
        {
            var entity = Items.FirstOrDefault(l => l.Id == id);
            return entity?.Name ?? 
                throw new BadRequestException(propertyName, $"Unknown id: {id} has been passed for entity {typeof(TEntity)}");
        }
        
        public long GetId(string name, [CallerMemberName] string propertyName = "")
        {
            var entity = Items.FirstOrDefault(l => l.Name == name);
            return entity?.Id ?? 
                   throw new BadRequestException(propertyName, $"Unknown name: {name} has been passed for entity {typeof(TEntity)}");
        }
        
        public void EnsureExists(string name, [CallerMemberName] string propertyName = "")
        {
            _ = GetId(name);
        }
    }
}