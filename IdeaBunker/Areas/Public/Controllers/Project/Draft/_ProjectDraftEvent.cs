using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectDraftController : Controller
{

    public async Task<ProjectEvent?> GetProjectEventAsync(string userId, string projectId, string action)
    {
        var projectEvent = await _context.ProjectsEvent
            .Where(p => p.UserId == userId && p.ProjectId == projectId && p.Action == action)
            .OrderByDescending(p => p.Date)
            .FirstOrDefaultAsync();
        return projectEvent;
    }

    public async Task AddProjectAsync(ProjectViewModel model)
    {
        model ??= new();
        Project project = new()
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Add(project);
        await _context.SaveChangesAsync();
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
            CategoryId = project.CategoryId,
            StatusId = project.StatusId,
            CategoryName = GetCategoryName(project!.CategoryId),
            StatusName = GetStatusName(project!.StatusId),
        };
        return model;
    }

    public async Task<ProjectDetailsViewModel> SetProjectDetailsViewModelAsync(string id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id)!;
        ProjectDetailsViewModel model = new()
        {
            Id = project!.Id,
            Name = project!.Name,
            UserNameAndRank = await GetNameAndRankAsync(project!.UserId),
            Description = project!.Description,
            CategoryDescription = $"{project?.Category?.Name}: {project?.Category?.Description}",
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",
        };
        return model;
    }

    public async Task UpdateProjectAsync(ProjectViewModel model)
    {
        model ??= new();
        Project project = new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Update(project);
        await _context.SaveChangesAsync();
    }
}