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
    
    public DbSet<WordTopic> WordTopics { get; init; }
    
    public DbSet<Translation> Translations { get; init; }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<RepeatSession> RepeatSessions { get; init; }
    
    public DbSet<RepeatSessionTranslation> RepeatSessionTranslations { get; init; }
    
    public DbSet<TranslationState> TranslationStates { get; init; }
    
    public DbSet<LearnedTranslation> LearnedTranslations { get; init; }

    public DbSet<UserQuiz> UserQuizzes { get; init; }

    public DbSet<UserQuizQuestion> UserQuizQuestions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Meaning>()
            .HasKey(x => new { x.WordId, x.Id });
        
        modelBuilder.Entity<WordTopic>()
            .HasKey(x => new { x.WordId, x.TopicId });

        modelBuilder.Entity<RepeatSession>()
            .HasIndex(x => new { x.UserId })
            .HasFilter($"state <> {RepeatState.Finished:D}")
            .IsUnique();
        
        modelBuilder.Entity<RepeatSessionTranslation>()
            .HasKey(x => new { x.WordId, x.MeaningId, x.TranslationId, x.RepeatSessionId });

        modelBuilder.Entity<RepeatSessionTranslation>()
            .HasForeignKeyToTranslation(x => x.RepeatSessionTranslations)
            .HasForeignKeyToWord(x => x.RepeatSessionTranslations);
        
        modelBuilder.Entity<Word>()
            .HasIndex(x => x.Text);

        modelBuilder.Entity<Translation>()
            .HasKey(x => new { x.WordId, x.Id, x.LanguageId });
        
        modelBuilder.Entity<Translation>()
            .HasForeignKeyToWord(x => x.Translations);
        
        modelBuilder.Entity<TranslationState>()
            .HasKey(x => new { x.WordId, x.TranslationId, x.UserId });
        
        modelBuilder.Entity<TranslationState>()
            .HasForeignKeyToTranslation(x => x.TranslationStates)
            .HasForeignKeyToWord(x => x.TranslationStates);
        
        modelBuilder.Entity<WordLanguage>().HasData(DefaultContextData.WordLanguages.Items);
        modelBuilder.Entity<CefrLevel>().HasData(DefaultContextData.CefrLevels.Items);
        modelBuilder.Entity<Topic>().HasData(DefaultContextData.WordTopics.Items);
        modelBuilder.Entity<PartOfSpeech>().HasData(DefaultContextData.PartOfSpeeches.Items);
        
        modelBuilder.Entity<LearnedTranslation>()
            .HasIndex(x => new { x.UserId, x.LearnedAt });
        
        modelBuilder.Entity<UserQuiz>()
            .HasIndex(x => x.UserId);
        
        modelBuilder.Entity<UserQuiz>()
            .HasIndex(x => x.LanguageId);
        
        modelBuilder.Entity<UserQuizQuestion>()
            .HasIndex(x => x.QuizId);
        
        modelBuilder.Entity<UserQuizQuestion>()
            .HasIndex(x => x.TranslationId);
        
        foreach (var word in DefaultContextData.Words)
        {
            modelBuilder.Entity<Word>()
                .HasData(new Word
                {
                    Id = word.Id,
                    Text = word.Word,
                    CefrLevelId = word.CefrLevel is not null ? DefaultContextData.CefrLevels.GetId(word.CefrLevel) : null,
                    Transcription = word.Transcription,
                    PartOfSpeechId = DefaultContextData.PartOfSpeeches.GetId(word.PartOfSpeech),
                    LanguageId =  DefaultContextData.WordLanguages.GetId("en"),
                });
            
            foreach (var topic in word.Topics)
            {
                modelBuilder.Entity<WordTopic>()
                    .HasData(new WordTopic
                    {
                        WordId = word.Id,
                        TopicId = DefaultContextData.WordTopics.GetId(topic),
                    });
            }

            foreach (var translation in word.Translations)
            {
                modelBuilder.Entity<Translation>()
                    .HasData(new Translation
                    {
                        Id = translation.Id,
                        Text = translation.Text,
                        LanguageId = DefaultContextData.WordLanguages.GetId(translation.Language),
                        WordId = word.Id,
                        Transcription = translation.Transcription,
                    });
            }
        }
    }
}