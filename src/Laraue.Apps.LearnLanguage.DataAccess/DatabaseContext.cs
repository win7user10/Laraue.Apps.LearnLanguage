using System.Reflection;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) 
        : base(options)
    {
    }
    
    public DbSet<WordLanguage> Languages { get; init; }
    
    public DbSet<Word> Words { get; init; }
    
    public DbSet<WordCefrLevel> WordCefrLevels { get; init; }
    
    public DbSet<WordTopic> WordTopics { get; init; }
    
    public DbSet<WordMeaning> WordMeanings { get; init; }
    
    public DbSet<WordMeaningTopic> WordMeaningTopics { get; init; }
    
    public DbSet<WordTranslation> WordTranslations { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<RepeatSession> RepeatSessions { get; init; }
    
    public DbSet<RepeatSessionWordTranslation> RepeatSessionWords { get; init; }
    
    public DbSet<WordTranslationState> WordTranslationStates { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Word>()
            .HasIndex(x => new { x.Name, x.LanguageId })
            .IsUnique();
        
        modelBuilder.Entity<WordTranslation>()
            .HasIndex(x => new { x.WordMeaningId, x.LanguageId })
            .IsUnique();
        
        modelBuilder.Entity<WordTranslationState>()
            .HasIndex(x => new { x.WordTranslationId, x.UserId })
            .IsUnique();
        
        modelBuilder.Entity<WordMeaningTopic>()
            .HasKey(x => new { x.WordMeaningId, x.WordTopicId });
        
        modelBuilder.Entity<RepeatSessionWordTranslation>()
            .HasIndex(x => new { x.WordTranslationId, x.RepeatSessionId })
            .IsUnique();

        modelBuilder.Entity<RepeatSession>()
            .HasIndex(x => new { x.UserId })
            .HasFilter($"state <> {RepeatState.Finished:D}")
            .IsUnique();

        var languagesDict = DefaultContextData.WordLanguages.ToDictionary(x => x.Code, x => x.Id);
        var cefrLevelsDict = DefaultContextData.CefrLevels.ToDictionary(x => x.Name, x => x.Id);
        var topicsDict = DefaultContextData.WordTopics.ToDictionary(x => x.Name, x => x.Id);
        
        modelBuilder.Entity<WordLanguage>().HasData(DefaultContextData.WordLanguages);
        modelBuilder.Entity<WordCefrLevel>().HasData(DefaultContextData.CefrLevels);
        modelBuilder.Entity<WordTopic>().HasData(DefaultContextData.WordTopics);
        
        foreach (var word in DefaultContextData.Words)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = word.Id,
                    Name = word.Word,
                    LanguageId = languagesDict[word.Language],
                    Transcription = word.Transcription,
                });

            foreach (var meaning in word.Meanings)
            {
                modelBuilder.Entity<WordMeaning>()
                    .HasData(new WordMeaning
                    {
                        Id = meaning.Id,
                        WordCefrLevelId = meaning.Level is not null ? cefrLevelsDict[meaning.Level] : null,
                        Meaning = meaning.Meaning,
                        WordId = word.Id,
                    });
                
                foreach (var topic in meaning.Topics)
                {
                    modelBuilder.Entity<WordMeaningTopic>()
                        .HasData(new WordMeaningTopic
                        {
                            WordTopicId = topicsDict[topic],
                            WordMeaningId = meaning.Id,
                        });
                }

                foreach (var translation in meaning.Translations)
                {
                    modelBuilder.Entity<WordTranslation>()
                        .HasData(new WordTranslation
                        {
                            Id = translation.Id,
                            Translation = translation.Text,
                            LanguageId = languagesDict[translation.Language],
                            WordMeaningId = meaning.Id,
                        });
                }
            }
        }
    }
}