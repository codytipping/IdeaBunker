using IdeaBunker.Areas.Private.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public interface IPrivateDataService 
{
    string GetClearanceName(string id);
    Task<string> GetClearanceNameAsync(string userId);
}

public class PrivateDataService : IPrivateDataService
{
    private readonly PrivateContext _context;
    private readonly UserManager<User> _userManager;

    public PrivateDataService(PrivateContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

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