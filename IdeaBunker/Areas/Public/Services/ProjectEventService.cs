using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Services;

public interface IProjectEventService
{
    Task<Project> GetProjectInfoAsync(string id);
    Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync();
    Task SetEventAsync(ProjectViewModel viewModel, string id);
    Task SetProjectAsync(ProjectViewModel viewModel);
    ProjectViewModel SetProjectViewModel(Project project);
    Task UpdateProjectAsync(ProjectViewModel viewModel);
}

public class ProjectEventService : IProjectEventService
{
    private readonly PublicContext _context;
    private readonly UserDataService _dataService;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContext;

    public ProjectEventService(
        PublicContext context, 
        UserManager<User> userManager, 
        UserDataService dataService,
        IHttpContextAccessor httpContext)
    {
        _context = context;
        _userManager = userManager;
        _dataService = dataService;
        _httpContext = httpContext;
    }

    public async Task<Project> GetProjectInfoAsync(string id)
    {
        var project = await _context.Projects
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project ?? new();
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = _httpContext.HttpContext?.User ?? new();
        var userId = _userManager.GetUserId(user) ?? string.Empty;
        var userNameAndRank = await _dataService.GetNameAndRankAsync(userId) ?? string.Empty;
        return (userId, userNameAndRank);
    }

    public async Task SetEventAsync(ProjectViewModel viewModel, string id)
    {
        //var securityCount = await _userLockoutService.GetSecurityCountAsync<ProjectCreate>(userId);
        var (userId, userName) = await GetUserInfoAsync();
        ProjectEvent projectEvent = new()
        {
            ProjectId = id,
            ProjectName = viewModel.Name,
            Action = viewModel.Action,
            UserId = userId,
            UserNameAndRank = userName,
            Description = viewModel.Description,
            EventDescription = viewModel.EventDescription,
            SecurityCount = 0, //Change this later.
        };
        _context.Add(projectEvent);
        await _context.SaveChangesAsync();
    }

    public async Task SetProjectAsync(ProjectViewModel viewModel)
    {
        var user = _httpContext.HttpContext?.User ?? new();
        var userId = _userManager.GetUserId(user) ?? string.Empty;
        Project project = new()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            CategoryId = viewModel.CategoryId ?? string.Empty,
            ClearanceId = viewModel.ClearanceId ?? string.Empty,
            StatusId = viewModel.StatusId ?? string.Empty,
            UserId = userId,
        };
        _context.Add(project);
        await _context.SaveChangesAsync();
        await SetEventAsync(viewModel, project.Id);
    }

    public ProjectViewModel SetProjectViewModel(Project project)
    {
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

    public async Task UpdateProjectAsync(ProjectViewModel viewModel)
    {
        var user = _httpContext.HttpContext?.User ?? new();
        var userId = _userManager.GetUserId(user) ?? string.Empty;
        Project project = new()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            CategoryId = viewModel.CategoryId ?? string.Empty,
            ClearanceId = viewModel.ClearanceId ?? string.Empty,
            StatusId = viewModel.StatusId ?? string.Empty,
            UserId = userId,
            UpvoteCount = viewModel.UpvoteCount,
            DownvoteCount = viewModel.DownvoteCount,
        };
        _context.Update(project);
        await _context.SaveChangesAsync();
        await SetEventAsync(viewModel, project.Id);
    }
}