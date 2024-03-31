using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Laraue.Apps.LearnLanguage.DataAccess.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static KeyBuilder HasTranslationKey<T>(this EntityTypeBuilder<T> builder)
        where T : class, IEntityWithTranslationReference
    {
        return builder.HasKey(x => new { x.WordId, x.MeaningId, x.TranslationId });
    }
    
    public static EntityTypeBuilder<T> HasForeignKeyToTranslation<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<Translation, IEnumerable<T>?>> backReference)
        where T : class, IEntityWithTranslationReference
    {
        builder.HasOne(x => x.Translation)
            .WithMany(backReference)
            .HasForeignKey(x => new { x.WordId, x.MeaningId, x.TranslationId  })
            .HasPrincipalKey(x => new { x.WordId, x.MeaningId, x.Id });

        return builder;
    }
    
    public static EntityTypeBuilder<T> HasForeignKeyToMeaning<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<Meaning, IEnumerable<T>?>> backReference)
        where T : class, IEntityWithMeaningReference
    {
        builder.HasOne(x => x.Meaning)
            .WithMany(backReference)
            .HasForeignKey(x => new { x.WordId, x.MeaningId })
            .HasPrincipalKey(x => new { x.WordId, x.Id });

        return builder;
    }
    
    public static EntityTypeBuilder<T> HasForeignKeyToWord<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<Word, IEnumerable<T>?>> backReference)
        where T : class, IEntityWithWordReference
    {
        builder.HasOne(x => x.Word)
            .WithMany(backReference)
            .HasForeignKey(x => x.WordId)
            .HasPrincipalKey(x => x.Id);

        return builder;
    }
}