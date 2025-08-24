using LinqToDB;

namespace Laraue.Apps.LearnLanguage.DataAccess;

public static class SqlFunctions
{
    [Sql.Function("gen_random_uuid", ServerSideOnly = true, CanBeNull = false, IsPure = false)]
    public static Guid NewGuid() => Guid.NewGuid();
}