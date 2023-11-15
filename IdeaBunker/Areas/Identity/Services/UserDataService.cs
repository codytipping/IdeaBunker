namespace IdeaBunker.Services;

public partial interface IDataService
{
    Task<string> GetNameAndRankAsync(string userId);
    Task<string> GetRankNameAsync(string userId);
}

public partial class DataService : IDataService
{
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