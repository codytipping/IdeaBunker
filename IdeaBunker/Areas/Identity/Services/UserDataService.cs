using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public interface IUserDataService
{
    Task<string> GetNameAndRankAsync(string userId);
    Task<string> GetRankNameAsync(string userId);
}

public class UserDataService : IUserDataService
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;

    public UserDataService(Context context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<string> GetNameAndRankAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return $"{user?.FirstName} {user?.LastName}, {rankName}" ?? string.Empty;
    }

    public async Task<string> GetRankNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return rankName ??= string.Empty;
    }
}