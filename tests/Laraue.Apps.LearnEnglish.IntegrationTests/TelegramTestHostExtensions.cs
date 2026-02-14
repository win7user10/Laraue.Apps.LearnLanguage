using Laraue.Apps.LearnLanguage.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public static class TelegramTestHostExtensions
{
    extension(AppTelegramTestHost telegramTestHost)
    {
        public IQueryable<T> GetDbSet<T>(Func<DatabaseContext, DbSet<T>> setSelector) where T : class
        {
            var dbContext = telegramTestHost.GetRequiredService<DatabaseContext>();
            return setSelector(dbContext).AsNoTracking();
        }
    }
}