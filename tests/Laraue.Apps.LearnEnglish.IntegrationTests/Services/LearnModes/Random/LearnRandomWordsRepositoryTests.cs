using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;
using Laraue.Core.DateTime.Extensions;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Services.LearnModes.Random;

public class LearnRandomWordsRepositoryTests : TestWithDatabase
{
    private readonly LearnRandomWordsRepository _repository;
    private readonly DateTime _now = new DateTime(2021, 01, 01).UseUtcKind();
    private const int DefaultTranslationId = 1;

    public LearnRandomWordsRepositoryTests()
    {
        var dateTimeProviderMock = new Mock<IDateTimeProvider>();
        dateTimeProviderMock.Setup(x => x.UtcNow).Returns(_now);
        
        _repository = new LearnRandomWordsRepository(GetDbContext(), dateTimeProviderMock.Object);
    }

    [Fact]
    public async Task LearnWord_ShouldUpdateOnlyRepeatedDate_WhenLearnDateIsSetAsync()
    {
        // Arrange
        var learnedAt = new DateTime(2020, 01, 01).UseUtcKind();

        await using var dbContext = GetDbContext();
        {
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordTranslationId = DefaultTranslationId,
                UserId = Users.User1.Id,
                LearnedAt = learnedAt
            });

            var session = new RepeatSession
            {
                UserId = Users.User1.Id,
                Words = new List<RepeatSessionTranslation>
                {
                    new() { WordTranslationId = DefaultTranslationId },
                }
            };
        
            dbContext.RepeatSessions.Add(session);
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.LearnWordAsync(session.Id, DefaultTranslationId);
        }

        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(learnedAt, state.LearnedAt);
        Assert.Equal(_now, state.RepeatedAt);
    }
    
    [Fact]
    public async Task LearnWord_ShouldSetOnlyLearnDate_WhenLearnDateIsNotSetAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            dbContext.TranslationStates.Add(new TranslationState
            {
                WordTranslationId = DefaultTranslationId,
                UserId = Users.User1.Id,
            });

            var session = new RepeatSession
            {
                UserId = Users.User1.Id,
                Words = new List<RepeatSessionTranslation>
                {
                    new() { WordTranslationId = DefaultTranslationId },
                }
            };
        
            dbContext.RepeatSessions.Add(session);
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.LearnWordAsync(session.Id, DefaultTranslationId);
        }

        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(_now, state.LearnedAt);
        Assert.Null(state.RepeatedAt);
    }
    
    [Fact]
    public async Task LearnWord_ShouldCreateNewTranslationState_IfItIsNotExistsAsync()
    {
        // Arrange
        await using var dbContext = GetDbContext();
        {
            var session = new RepeatSession
            {
                UserId = Users.User1.Id,
                Words = new List<RepeatSessionTranslation>
                {
                    new() { WordTranslationId = DefaultTranslationId },
                }
            };
        
            dbContext.RepeatSessions.Add(session);
            await dbContext.SaveChangesAsync();
            
            // Act
            await _repository.LearnWordAsync(session.Id, DefaultTranslationId);
        }

        // Assert
        var state = await GetDbContext().TranslationStates.SingleAsyncEF();
        
        Assert.Equal(_now, state.LearnedAt);
        Assert.Null(state.RepeatedAt);
    }
}