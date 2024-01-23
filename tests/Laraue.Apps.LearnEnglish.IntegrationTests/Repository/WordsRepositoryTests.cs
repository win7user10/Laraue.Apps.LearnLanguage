using System;
using System.Linq;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
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
            await _repository.IncrementLearnAttemptsIfRequiredAsync(Users.User1.Id, [1L]);
        }
        
        // Assert
        var state = await GetDbContext().WordTranslationStates.SingleAsyncEF();
        
        Assert.Equal(1, state.LearnAttempts);
        Assert.Equal(_now, state.LastOpenedAt);
        Assert.Equal(Users.User1.Id, state.UserId);
        Assert.Equal(1, state.WordTranslationId);
    }

    [Fact]
    public async Task IncrementLearnAttempts_ShouldMakeIncrement_OnlyWhenHourPassedSinceLastIncrementAsync()
    {
        // Arrange
        var dateShouldBeUpdated = _now.AddHours(1).UseUtcKind();
        var dateShouldBeNotUpdated = _now.AddMinutes(59).UseUtcKind();

        await using var dbContext = GetDbContext();
        {
            dbContext.WordTranslationStates.Add(new WordTranslationState
            {
                WordTranslationId = 1,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeUpdated,
                LearnState = LearnState.None
            });
            
            dbContext.WordTranslationStates.Add(new WordTranslationState
            {
                WordTranslationId = 2,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeUpdated,
                LearnState = LearnState.Learned
            });

            dbContext.WordTranslationStates.Add(new WordTranslationState
            {
                WordTranslationId = 3,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeNotUpdated,
                LearnState = LearnState.None
            });
            
            dbContext.WordTranslationStates.Add(new WordTranslationState
            {
                WordTranslationId = 4,
                UserId = Users.User1.Id,
                LastOpenedAt = dateShouldBeNotUpdated,
                LearnState = LearnState.Learned
            });
        
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.IncrementLearnAttemptsIfRequiredAsync(Users.User1.Id, [1L, 2, 3, 4]);
        }
        
        // Assert
        var states = await GetDbContext()
            .WordTranslationStates
            .OrderBy(x => x.Id)
            .ToArrayAsyncEF();
        
        Assert.Equal(1, states[0].LearnAttempts);
        Assert.Equal(_now, states[0].LastOpenedAt);
        Assert.Equal(0, states[1].LearnAttempts);
        Assert.Equal(dateShouldBeUpdated, states[1].LastOpenedAt);
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
            await _repository.ChangeWordLearnStateAsync(Users.User1.Id, 1, LearnState.Learned);
        }
        
        // Assert
        var state = await GetDbContext().WordTranslationStates.SingleAsyncEF();
        
        Assert.Equal(1, state.LearnAttempts);
        Assert.Equal(DateTime.MinValue, state.LastOpenedAt);
        Assert.Equal(Users.User1.Id, state.UserId);
        Assert.Equal(1, state.WordTranslationId);
        Assert.Equal(LearnState.Learned, state.LearnState);
    }
    
    [Fact]
    public async Task ChangeWordLearnState_ShouldUpdateState_WhenItExistsAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            dbContext.WordTranslationStates.Add(new WordTranslationState
            {
                WordTranslationId = 1,
                UserId = Users.User1.Id,
                LearnState = LearnState.None,
                LastOpenedAt = _now
            });
            
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.ChangeWordLearnStateAsync(Users.User1.Id, 1, LearnState.Learned);
        }
        
        // Assert
        var state = await GetDbContext().WordTranslationStates.SingleAsyncEF();
        
        Assert.Equal(0, state.LearnAttempts);
        Assert.Equal(_now, state.LastOpenedAt);
        Assert.Equal(LearnState.Learned, state.LearnState);
    }
}