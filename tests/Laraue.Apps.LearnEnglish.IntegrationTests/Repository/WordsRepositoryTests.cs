using System;
using System.Linq;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Core.DateTime.Extensions;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Repository;

public class WordsRepositoryTests : TestWithDatabase
{
    private readonly WordsRepository _repository;
    private readonly DateTime _now = new DateTime(2021, 01, 01).UseUtcKind();

    public WordsRepositoryTests()
    {
        var dateTimeProviderMock = new Mock<IDateTimeProvider>();
        dateTimeProviderMock.Setup(x => x.UtcNow).Returns(_now);
        
        _repository = new WordsRepository(GetDbContext(), dateTimeProviderMock.Object);
    }
    
    [Fact]
    public async Task IncrementLearnAttempts_ShouldInsertNewState_WhenItNotExistsAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            // Act
            await _repository.IncrementLearnAttemptsIfRequiredAsync(
                Users.User1.Id,
                [
                    new TranslationIdentifier { WordId = 3, MeaningId = 1, TranslationId = 1 }
                ]);
        }
        
        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(1, state.LearnAttempts);
        Assert.Equal(_now, state.LastOpenedAt);
        Assert.Equal(Users.User1.Id, state.UserId);
        Assert.Equal(3, state.WordId);
        Assert.Equal(1, state.MeaningId);
        Assert.Equal(1, state.TranslationId);
    }

    [Fact]
    public async Task IncrementLearnAttempts_ShouldMakeIncrement_OnlyWhenHourPassedSinceLastIncrementAsync()
    {
        // Arrange
        var dateShouldBeUpdated = _now.AddHours(1).UseUtcKind();
        var dateShouldBeNotUpdated = _now.AddMinutes(59).UseUtcKind();

        await using var dbContext = GetDbContext();
        {
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordId = 1,
                MeaningId = 1,
                TranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeUpdated,
            });
            
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordId = 2,
                MeaningId = 1,
                TranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeUpdated,
                LearnedAt = _now.AddHours(-1)
            });

            dbContext.TranslationStates.Add(new TranslationState
            {
                WordId = 3,
                MeaningId = 1,
                TranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeNotUpdated,
            });
            
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordId = 4,
                MeaningId = 1,
                TranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeNotUpdated,
                LearnedAt = _now.AddHours(-1)
            });
        
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.IncrementLearnAttemptsIfRequiredAsync(
                Users.User1.Id,
                [
                    new TranslationIdentifier { WordId = 1, MeaningId = 1, TranslationId = 1 },
                    new TranslationIdentifier { WordId = 2, MeaningId = 1, TranslationId = 1 },
                    new TranslationIdentifier { WordId = 3, MeaningId = 1, TranslationId = 1 },
                    new TranslationIdentifier { WordId = 4, MeaningId = 1, TranslationId = 1 },
                ]);
        }
        
        // Assert
        var states = await GetDbContext()
            .TranslationStates
            .OrderBy(x => x.WordId)
            .ToArrayAsyncEF();
        
        Assert.Equal(1, states[0].LearnAttempts);
        Assert.Equal(_now, states[0].LastOpenedAt);
        Assert.Equal(0, states[1].LearnAttempts);
        Assert.Equal(_now, states[1].LastOpenedAt);
        Assert.Equal(0, states[2].LearnAttempts);
        Assert.Equal(dateShouldBeNotUpdated, states[2].LastOpenedAt);
        Assert.Equal(0, states[3].LearnAttempts);
        Assert.Equal(dateShouldBeNotUpdated, states[3].LastOpenedAt);
    }

    [Fact]
    public async Task ChangeWordLearnState_ShouldInsertNewState_WhenItNotExistsAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            // Act
            await _repository.ChangeWordLearnStateAsync(
                Users.User1.Id,
                new TranslationIdentifier { WordId = 3, MeaningId = 1, TranslationId = 1 },
                true,
                null);
        }
        
        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(1, state.LearnAttempts);
        Assert.Equal(_now, state.LastOpenedAt);
        Assert.Equal(Users.User1.Id, state.UserId);
        Assert.Equal(3, state.WordId);
        Assert.Equal(1, state.MeaningId);
        Assert.Equal(1, state.TranslationId);
        Assert.Equal(_now, state.LearnedAt);
    }
    
    [Fact]
    public async Task ChangeWordLearnState_ShouldUpdateState_WhenItExistsAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordId = 3,
                MeaningId = 1,
                TranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = _now
            });
            
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.ChangeWordLearnStateAsync(
                Users.User1.Id,
                new TranslationIdentifier { WordId = 3, MeaningId = 1, TranslationId = 1 },
                true,
                null);
        }
        
        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(0, state.LearnAttempts);
        Assert.Equal(_now, state.LastOpenedAt);
        Assert.Equal(_now, state.LearnedAt);
    }
}