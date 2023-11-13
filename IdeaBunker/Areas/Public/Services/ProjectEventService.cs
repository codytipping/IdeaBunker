using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Services;

public interface IProjectEventService
{
    Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync();
    Task SetEventAsync(ProjectViewModel viewModel, string id);
    Task SetProjectAsync(ProjectViewModel viewModel);
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

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = _httpContext.HttpContext?.User ?? new();
        var userId = _userManager.GetUserId(user) ?? string.Empty;
        var userNameAndRank = await _dataService.GetFullNameAndRankAsync(userId) ?? string.Empty;
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
}