using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Controllers;

public partial class HomeController : Controller
{
    public string GetCategoryName(string id)
    {
        return _context.Categories.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefault()!;
    }

    public string GetStatusName(string id)
    {
        return _context.ProjectsStatus.Where(s => s.Id == id).Select(s => s.Name).FirstOrDefault()!;
    }

    public async Task<IList<Project>> GetProjectsAsync()
    {
        var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name != "Unpublished")
            .Include(p => p.Category)
            .Include(p => p.User)
            .Include(p => p.Status)
            .ToListAsync();
        return projects!;
    }

    public async Task<ProjectViewModel> SetProjectViewModelAsync(string id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id)!;
        ProjectViewModel model = new()
        {
            Id = project!.Id,
            Name = project.Name,
            Description = project.Description,
            UpvoteCount = project.UpvoteCount,
            DownvoteCount = project.DownvoteCount,
            CategoryName = GetCategoryName(project!.CategoryId),
            StatusName = GetStatusName(project!.StatusId),
        };
        return model;
    }
}