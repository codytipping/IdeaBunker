namespace IdeaBunker.Services;

public partial interface IDataService 
{
    string GetClearanceName(string id);
    Task<string> GetClearanceNameAsync(string userId);
}

public partial class DataService : IDataService
{
    public string GetClearanceName(string id)
    {
        var clearanceName = _context.Clearances
            .Where(c => c.Id == id)
            .Select(c => c.Name)
            .FirstOrDefault();
        return clearanceName ?? string.Empty;
    }

    public async Task<string> GetClearanceNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var clearanceName = _context.Clearances
            .Where(c => user != null && c.Id == user.ClearanceId)
            .Select(c => c.Name)
            .FirstOrDefault();
        return clearanceName ??= string.Empty;
    }
}