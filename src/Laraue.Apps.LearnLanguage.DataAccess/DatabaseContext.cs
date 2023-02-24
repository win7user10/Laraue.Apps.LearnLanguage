using System.Reflection;
using System.Text.Json;
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
    
    public DbSet<WordTranslation> WordTranslations { get; init; }
    
    public DbSet<WordGroup> WordGroups { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<WordGroupWord> WordGroupWords { get; init; }
    
    public DbSet<WordTranslationState> WordTranslationStates { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<WordGroup>()
            .HasIndex(x => x.SerialNumber);
        
        modelBuilder.Entity<WordGroup>()
            .HasIndex(x => x.UserId);
        
        modelBuilder.Entity<WordGroupWord>()
            .HasIndex(x => x.SerialNumber);
        
        modelBuilder.Entity<WordTranslationState>()
            .HasIndex(x => new { x.WordTranslationId, x.UserId })
            .IsUnique();

        var languages = new TranslationLanguage[]
        {
            new () { Id = 1, Code = "ru" }
        };

        var languagesDictionary = languages
            .ToDictionary(
                x => x.Code,
                x => x.Id );
        
        modelBuilder.Entity<TranslationLanguage>().HasData(languages);
        
        using var fileStream = File.OpenRead(
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "translations.json"));

        var words = JsonSerializer.Deserialize<ImportingWord[]>(
            fileStream,
            new JsonSerializerOptions(JsonSerializerDefaults.Web))!;
        
        foreach (var word in words)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = word.Id,
                    Name = word.Word,
                });

            foreach (var translation in word.Translations)
            {
                modelBuilder.Entity<WordTranslation>()
                    .HasData(new WordTranslation
                    {
                        Id = translation.Id,
                        Translation = string.Join(" | ", translation.Translations),
                        LanguageId = languagesDictionary[translation.Language],
                        WordId = word.Id,
                    });
            }
        }
    }

    private record struct ImportingWord(int Id, string Word, ImportingTranslation[] Translations);
    private record struct ImportingTranslation(int Id, string Language, string[] Translations);
}