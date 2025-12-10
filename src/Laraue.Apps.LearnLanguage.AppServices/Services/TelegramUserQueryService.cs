using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Telegram.NET.Authentication.Services;
using LinqToDB.EntityFrameworkCore;
using User = Laraue.Apps.LearnLanguage.DataAccess.Entities.User;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public class TelegramUserQueryService(DatabaseContext context)
    : ITelegramUserQueryService<User, Guid>
{
    public Task<User?> FindAsync(long telegramId)
    {
        return context.Users
            .Where(u => u.TelegramId == telegramId)
            .FirstOrDefaultAsyncEF();
    }

    public async Task<Guid> CreateAsync(User user)
    {
        context.Users.Add(user);
        
        await context.SaveChangesAsync();
        
        return user.Id;
    }
}