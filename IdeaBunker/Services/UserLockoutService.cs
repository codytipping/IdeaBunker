using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Services;

public interface IUserLockoutService
{
    Task<int> GetSecurityCountAsync<T>(string id) where T : class;
    Task LockoutUserAsync(string id);
    Task VerifyCountAsync(string id);
}
public class UserLockoutService : IUserLockoutService
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserLockoutService(Context context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    private const int targetCount = 100;
    private static int securityCount = 0;

    public async Task<int> GetSecurityCountAsync<T>(string id) where T : class
    {
        DateTime currentDate = DateTime.UtcNow.Date;
        securityCount = _context.Set<T>()
            .Where(entry => EF.Property<string>(entry, "UserId") == id &&
                            EF.Property<DateTime>(entry, "Date").Date == currentDate)
            .OrderByDescending(entry => EF.Property<DateTime>(entry, "Date"))
            .Select(entry => EF.Property<int>(entry, "SecurityCount"))
            .FirstOrDefault();
        await VerifyCountAsync(id);
        return ++securityCount;
    }

    public async Task LockoutUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is not null)
        {
            user.LockoutEnd = DateTimeOffset.MaxValue;
            await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();
        }
    }

    public async Task VerifyCountAsync(string id)
    {
        if (securityCount == targetCount) await LockoutUserAsync(id);  
    }
}