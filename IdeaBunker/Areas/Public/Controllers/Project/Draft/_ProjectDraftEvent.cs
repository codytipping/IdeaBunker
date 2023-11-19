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

    public async Task SetProjectEventAsync(ProjectViewModel viewModel, string id)
    {
        var model = viewModel!;
        ProjectEvent projectEvent = new()
        {
            ProjectId = id,
            ProjectName = model.Name,
            VoteType = model.VoteType,
            Action = model.Action,
            UserId = model.UserId,
            UserNameAndRank = model.UserNameAndRank,
            Description = model.Description,
            EventDescription = model.EventDescription,
            SecurityCount = model.SecurityCount,
        };
        _context.Add(projectEvent);
        await _context.SaveChangesAsync();
    }

    public async Task AddProjectAsync(ProjectViewModel model)
    {
        model ??= new();
        Project project = new()
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            ClearanceId = model.ClearanceId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Add(project);
        await _context.SaveChangesAsync();
        await SetProjectEventAsync(model, project.Id);
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
            ClearanceName = GetClearanceName(project!.ClearanceId),
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
            ClearanceDescription = $"{project?.Clearance?.Name}: {project?.Clearance?.Description}",
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
            ClearanceId = model.ClearanceId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Update(project);
        await _context.SaveChangesAsync();
        await SetProjectEventAsync(model, project.Id);
    }
}