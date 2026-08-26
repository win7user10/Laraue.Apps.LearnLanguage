using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Telegram.NET.Authentication.Services;
using LinqToDB.EntityFrameworkCore;
using User = Laraue.Apps.LearnLanguage.DataAccess.Entities.User;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public class TelegramUserQueryService(DatabaseContext context)
    : ITelegramUserQueryService<User, Guid>
{
    public Task<User?> FindAsync(long telegramId, CancellationToken cancellationToken)
    {
        return context.Users
            .Where(u => u.TelegramId == telegramId)
            .FirstOrDefaultAsyncEF(cancellationToken);
    }

    public async Task<Guid> CreateAsync(User user, CancellationToken cancellationToken)
    {
        context.Users.Add(user);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
}