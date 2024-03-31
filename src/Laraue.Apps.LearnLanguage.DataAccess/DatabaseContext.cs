using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.DataAccess.Extensions;
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
    
    public DbSet<CefrLevel> CefrLevels { get; init; }
    
    public DbSet<Topic> Topics { get; init; }
    
    public DbSet<Meaning> Meanings { get; init; }
    
    public DbSet<MeaningTopic> MeaningTopics { get; init; }
    
    public DbSet<Translation> Translations { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<RepeatSession> RepeatSessions { get; init; }
    
    public DbSet<RepeatSessionTranslation> RepeatSessionTranslations { get; init; }
    
    public DbSet<TranslationState> TranslationStates { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Meaning>()
            .HasKey(x => new { x.WordId, x.Id });
        
        modelBuilder.Entity<Meaning>()
            .HasForeignKeyToWord(x => x.Meanings);
        
        modelBuilder.Entity<MeaningTopic>()
            .HasKey(x => new { x.WordId, x.MeaningId, WordTopicId = x.TopicId });
        
        modelBuilder.Entity<MeaningTopic>()
            .HasForeignKeyToMeaning(x => x.Topics)
            .HasForeignKeyToWord(x => x.Topics);

        modelBuilder.Entity<RepeatSession>()
            .HasIndex(x => new { x.UserId })
            .HasFilter($"state <> {RepeatState.Finished:D}")
            .IsUnique();
        
        modelBuilder.Entity<RepeatSessionTranslation>()
            .HasKey(x => new { x.WordId, x.MeaningId, x.TranslationId, x.RepeatSessionId });

        modelBuilder.Entity<RepeatSessionTranslation>()
            .HasForeignKeyToTranslation(x => x.RepeatSessionTranslations)
            .HasForeignKeyToMeaning(x => x.RepeatSessionTranslations)
            .HasForeignKeyToWord(x => x.RepeatSessionTranslations);
        
        modelBuilder.Entity<Word>()
            .HasIndex(x => new { Name = x.Text, x.LanguageId })
            .IsUnique();

        modelBuilder.Entity<Translation>()
            .HasKey(x => new { x.WordId, x.MeaningId, x.Id, x.LanguageId });
        
        modelBuilder.Entity<Translation>()
            .HasForeignKeyToMeaning(x => x.Translations)
            .HasForeignKeyToWord(x => x.Translations);
        
        modelBuilder.Entity<TranslationState>()
            .HasTranslationKey();
        
        modelBuilder.Entity<TranslationState>()
            .HasForeignKeyToTranslation(x => x.TranslationStates)
            .HasForeignKeyToMeaning(x => x.TranslationStates)
            .HasForeignKeyToWord(x => x.TranslationStates);
        
        modelBuilder.Entity<WordLanguage>().HasData(DefaultContextData.WordLanguages.Items);
        modelBuilder.Entity<CefrLevel>().HasData(DefaultContextData.CefrLevels.Items);
        modelBuilder.Entity<Topic>().HasData(DefaultContextData.WordTopics.Items);
        
        foreach (var word in DefaultContextData.Words)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = word.Id,
                    Text = word.Word,
                    LanguageId = DefaultContextData.WordLanguages.GetId(word.Language),
                    Transcription = word.Transcription,
                });

            foreach (var meaning in word.Meanings)
            {
                modelBuilder.Entity<Meaning>()
                    .HasData(new Meaning
                    {
                        Id = meaning.Id,
                        CefrLevelId = meaning.Level is not null ? DefaultContextData.CefrLevels.GetId(meaning.Level) : null,
                        Text = meaning.Meaning,
                        WordId = word.Id,
                    });
                
                foreach (var topic in meaning.Topics)
                {
                    modelBuilder.Entity<MeaningTopic>()
                        .HasData(new MeaningTopic
                        {
                            WordId = word.Id,
                            TopicId = DefaultContextData.WordTopics.GetId(topic),
                            MeaningId = meaning.Id,
                        });
                }

                foreach (var translation in meaning.Translations)
                {
                    modelBuilder.Entity<Translation>()
                        .HasData(new Translation
                        {
                            Id = translation.Id,
                            Text = translation.Text,
                            LanguageId = DefaultContextData.WordLanguages.GetId(translation.Language),
                            MeaningId = meaning.Id,
                            WordId = word.Id,
                        });
                }
            }
        }
    }
}