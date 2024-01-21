using System.Reflection;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) 
        : base(options)
    {
    }
    
    public DbSet<TranslationLanguage> Languages { get; init; }
    
    public DbSet<Word> Words { get; init; }
    
    public DbSet<WordCefrLevel> WordCefrLevels { get; init; }
    
    public DbSet<WordTopic> WordTopics { get; init; }
    
    public DbSet<WordTranslation> WordTranslations { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<RepeatSession> RepeatSessions { get; init; }
    
    public DbSet<RepeatSessionWordTranslation> RepeatSessionWords { get; init; }
    
    public DbSet<WordTranslationState> WordTranslationStates { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<WordTranslationState>()
            .HasIndex(x => new { x.WordTranslationId, x.UserId })
            .IsUnique();
        
        modelBuilder.Entity<RepeatSessionWordTranslation>()
            .HasIndex(x => new { x.WordTranslationId, x.RepeatSessionId });

        modelBuilder.Entity<RepeatSession>()
            .HasIndex(x => new { x.UserId })
            .HasFilter($"state <> {RepeatState.Finished:D}")
            .IsUnique();

        var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        var languages = new TranslationLanguage[]
        {
            new () { Id = 1, Code = "ru" }
        };

        var cefrLevels = new WordCefrLevel[]
        {
            new () { Id = 1, Name = "A1" },
            new () { Id = 2, Name = "A2" },
            new () { Id = 3, Name = "B1" },
            new () { Id = 4, Name = "B2" },
            new () { Id = 5, Name = "C1" },
            new () { Id = 6, Name = "C2" },
        };

        using var topicsStream = File.OpenRead(Path.Combine(assemblyDirectory, "topics.json"));
        var topics = JsonSerializer.Deserialize<WordTopic[]>(topicsStream, Constants.JsonWebOptions)!;

        var languagesDict = languages.ToDictionary(x => x.Code, x => x.Id);
        var cefrLevelsDict = cefrLevels.ToDictionary(x => x.Name, x => x.Id);
        var topicsDict = topics.ToDictionary(x => x.Name, x => x.Id);
        
        modelBuilder.Entity<TranslationLanguage>().HasData(languages);
        modelBuilder.Entity<WordCefrLevel>().HasData(cefrLevels);
        modelBuilder.Entity<WordTopic>().HasData(topics);
        
        using var translationsStream = File.OpenRead(Path.Combine(assemblyDirectory, "translations.json"));
        var words = JsonSerializer.Deserialize<ImportingWord[]>(
            translationsStream,
            Constants.JsonWebOptions)!;
        
        foreach (var word in words)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = word.Id,
                    Name = word.Word,
                    WordCefrLevelId = word.Level is not null ? cefrLevelsDict[word.Level] : null,
                    WordTopicId = word.Topic is not null ? topicsDict[word.Topic] : null
                });

            foreach (var translation in word.Translations)
            {
                modelBuilder.Entity<WordTranslation>()
                    .HasData(new WordTranslation
                    {
                        Id = translation.Id,
                        Translation = string.Join(" | ", translation.Translations),
                        LanguageId = languagesDict[translation.Language],
                        WordId = word.Id,
                    });
            }
        }
    }

    private record struct ImportingWord(
        int Id,
        string Word,
        ImportingTranslation[] Translations,
        string? Level,
        string? Topic);
    
    private record struct ImportingTranslation(int Id, string Language, string[] Translations);
}