using System.Threading.Tasks;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Queries;

public class GenerateGroupsCommandTests : TestWithDatabase
{
    [Fact]
    public async Task NewBatchShouldBeAddedCorrectlyAsync()
    {
        // await Mediator.Send(new GenerateGroupsCommand(Users.Id1, false));
    }
}