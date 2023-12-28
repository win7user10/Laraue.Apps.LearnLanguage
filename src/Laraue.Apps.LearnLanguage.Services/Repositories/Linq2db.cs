using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class Linq2db
{
    [Sql.Function("gen_random_uuid", ServerSideOnly = true, CanBeNull = false, IsPure = false)]
    public static Guid NewGuid() => Guid.NewGuid();
}