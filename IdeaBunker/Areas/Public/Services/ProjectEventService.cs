using IdeaBunker.Data;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Services;

public interface IProjectEventService
{
    Task<ProjectEvent?> GetEventAsync(string userId, string projectId);
    Task SetEventAsync(ProjectViewModel viewModel, string id);
    Task SetProjectAsync(ProjectViewModel viewModel);
    Task<ProjectViewModel> SetViewModelAsync(string id);
}

public class ProjectEventService : IProjectEventService
{
    private readonly Context _context;  
    private readonly UserLockoutService _lockoutService;

    public ProjectEventService(Context context, UserLockoutService lockoutService)
    {
        _context = context;
        _lockoutService = lockoutService;
    }

    public async Task<ProjectEvent?> GetEventAsync(string userId, string projectId)
    {
        var projectEvent = await _context.ProjectEvents
            .Where(p => p.UserId == userId && p.ProjectId == projectId)
            .OrderByDescending(p => p.Date)
            .FirstOrDefaultAsync();
        return projectEvent ?? null;
    }

    public async Task SetEventAsync(ProjectViewModel viewModel, string id)
    {
        var count = await _lockoutService.GetSecurityCountAsync<ProjectEvent>(viewModel.UserId);
        var model = viewModel ?? new();
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
            SecurityCount = count,
        };
        _context.Add(projectEvent);
        await _context.SaveChangesAsync();
    }

    public async Task SetProjectAsync(ProjectViewModel viewModel)
    {
        var model = viewModel ?? new();
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
        _context.Add(model.Update ? _context.Update(project) : project);
        await _context.SaveChangesAsync();
        await SetEventAsync(model, project.Id);
    }

    public async Task<ProjectViewModel> SetViewModelAsync(string id)
    {
        var project = await _context.Projects.FindAsync(id) ?? new();
        ProjectViewModel viewModel = new()
        {
            Name = project.Name,
            Description = project.Description,
            CategoryName = project?.Category?.Name ?? string.Empty,
            ClearanceName = project?.Clearance?.Name ?? string.Empty,
            StatusName = project?.Status?.Name ?? string.Empty,
        };
        return viewModel;
    }
}