using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Data;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public interface IUserDataService
{
    Task<string> GetFullNameAndRankAsync(string userId);
    Task<string> GetRankNameAsync(string userId);
}

public class UserDataService : IUserDataService
{
    private readonly IdentityContext _context;
    private readonly UserManager<User> _userManager;

    public UserDataService(IdentityContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<string> GetFullNameAndRankAsync(string userId)
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