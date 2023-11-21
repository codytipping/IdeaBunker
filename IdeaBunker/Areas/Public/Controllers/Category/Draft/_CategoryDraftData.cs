using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class CategoryDraftController : Controller
{
    public string GetStatusId(string name)
    {
        return _context.CategoriesStatus.Where(s => s.Name == name).Select(s => s.Id).FirstOrDefault()!;
    }

    public string GetStatusName(string id)
    {
        return _context.CategoriesStatus.Where(s => s.Id == id).Select(s => s.Name).FirstOrDefault()!;
    }

    public async Task<Category> GetCategoryInfoAsync(string id)
    {
        var category = await _context.Categories
            .Include(p => p.User)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(c => c.Id == id);
        return category!;
    }

    public async Task<IList<Category>> GetCategoriesAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var categories = await _context.Categories
            .Where(p => p.Status != null && p.UserId == user!.Id && p.Status.Name == "Unpublished")
            .Include(p => p.Status)
            .ToListAsync();
        return categories!;
    }

    public async Task<string> GetNameAndRankAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return $"{user!.FirstName} {user.LastName}, {rankName}";
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userNameAndRank = await GetNameAndRankAsync(user!.Id)!;
        return (user!.Id, userNameAndRank);
    }

    public async Task<CategoryViewModel> UpdateModelAsync(CategoryViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        return model;
    }
}