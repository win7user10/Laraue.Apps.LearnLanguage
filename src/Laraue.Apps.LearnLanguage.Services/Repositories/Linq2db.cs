using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class Linq2db
{
    [Sql.Function("uuid_generate_v4", ServerSideOnly = true, CanBeNull = false, IsPure = false)]
    public static Guid NewGuid() => Guid.NewGuid();
}