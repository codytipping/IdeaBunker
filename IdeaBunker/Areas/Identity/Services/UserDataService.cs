using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public static partial class DataService
{
    public static async Task<string> GetNameAndRankAsync(string userId, UserManager<User> manager, Context context)
    {
        var user = await manager.FindByIdAsync(userId);
        var rankName = context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return $"{user?.FirstName} {user?.LastName}, {rankName}" ?? string.Empty;
    }

    public static async Task<string> GetRankNameAsync(string userId, UserManager<User> manager, Context context)
    {
        var user = await manager.FindByIdAsync(userId);
        var rankName = context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return rankName ??= string.Empty;
    }
}