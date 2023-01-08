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
    
    public DbSet<Language> Languages { get; init; }
    
    public DbSet<Word> Words { get; init; }
    
    public DbSet<WordTranslation> WordTranslations { get; init; }
    
    public DbSet<WordGroup> WordGroups { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<WordGroupWords> WordGroupWordTranslations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<WordGroup>()
            .HasIndex(x => x.SerialNumber);
        
        modelBuilder.Entity<WordGroup>()
            .HasIndex(x => x.UserId);
        
        modelBuilder.Entity<WordGroupWords>()
            .HasIndex(x => x.LearnState);
        
        modelBuilder.Entity<WordGroupWords>()
            .HasIndex(x => x.SerialNumber);
        
        modelBuilder.Entity<Language>()
            .HasData(
                new () { Id = 1, Code = "en" },
                new () { Id = 2, Code = "ru" });
        
        using var fileStream = File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "en_ru_words.json"));

        var translations = JsonSerializer.Deserialize<string[][]>(fileStream)!
            .Select(x => new OneWord(x[0], x[1]))
            .GroupBy(x => x.Word)
            .Select(x => new OneWord(x.Key, string.Join(", ", x.Select(y => y.Translation))))
            .ToArray();

        for (var i = 0; i < translations.Length; i++)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = i + 1,
                    Name = translations[i].Word
                });
            
            modelBuilder.Entity<WordTranslation>()
                .HasData(new WordTranslation
                {
                    Id = i + 1,
                    Translation = translations[i].Translation,
                    LanguageId = 1,
                    WordId = i + 1,
                });
        }
    }

    private record struct OneWord(string Word, string Translation);
}