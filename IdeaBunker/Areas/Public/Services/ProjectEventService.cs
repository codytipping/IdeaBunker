using IdeaBunker.Data;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public interface IProjectEventService
{
    Task SetEventAsync(ProjectViewModel viewModel, string id);
    Task SetProjectAsync(ProjectViewModel viewModel);
    Task<ProjectViewModel> SetProjectViewModelAsync(string id);
}

public class ProjectEventService : IProjectEventService
{
    private readonly Context _context;    

    public ProjectEventService(Context context)
    {
        _context = context;
    }

    public async Task SetEventAsync(ProjectViewModel viewModel, string id)
    {
        //var securityCount = await _userLockoutService.GetSecurityCountAsync<ProjectCreate>(userId);
        var model = viewModel ?? new();
        ProjectEvent projectEvent = new()
        {
            ProjectId = id,
            ProjectName = model.Name,
            Action = model.Action,
            UserId = model.UserId,
            UserNameAndRank = model.UserNameAndRank,
            Description = model.Description,
            EventDescription = model.EventDescription,
            SecurityCount = 0, //Change this later.
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

    public async Task<ProjectViewModel> SetProjectViewModelAsync(string id)
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