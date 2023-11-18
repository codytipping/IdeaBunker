using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Private.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdeaBunker.Areas.Public.ViewModels.Projects;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectController : Controller
{
    public string GetCategoryId(string name)
    {
        return _context.Categories.Where(c => c.Name == name).Select(c => c.Id).FirstOrDefault()!;
    }

    public string GetCategoryName(string id)
    {
        return _context.Categories.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefault()!;
    }

    public string GetClearanceId(string name)
    {
        return _context.Clearances.Where(c => c.Name == name).Select(c => c.Id).FirstOrDefault()!;
    }

    public string GetClearanceName(string id)
    {
        return _context.Clearances.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefault()!;
    }

    public string GetStatusId(string name)
    {
        return _context.ProjectsStatus.Where(s => s.Name == name).Select(s => s.Id).FirstOrDefault()!;
    }

    public string GetStatusName(string id)
    {
        return _context.ProjectsStatus.Where(s => s.Id == id).Select(s => s.Name).FirstOrDefault()!;
    }

    public async Task<Project> GetProjectInfoAsync(string id)
    {
        var project = await _context.Projects
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project!;
    }

    public async Task<IList<Project>> GetProjectsAsync()
    {
        var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name != "Unpublished")
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .ToListAsync();
        return projects!;
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

    public async Task<string> GetRankNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return rankName ??= string.Empty;
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userNameAndRank = await GetNameAndRankAsync(user!.Id)!;
        return (user!.Id, userNameAndRank);
    }

    public async Task<ProjectViewModel> UpdateModelAsync(ProjectViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        return model;
    }
}