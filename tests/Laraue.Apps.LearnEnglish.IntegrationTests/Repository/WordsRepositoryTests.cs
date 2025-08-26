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
        
        _repository = new WordsRepository(GetDbContext());
    }
}