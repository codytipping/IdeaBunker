using IdeaBunker.Data;
using IdeaBunker.Models;
using IdeaBunker.Services;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Controllers;

public partial class ProjectsController : Controller
{
    private readonly Context _context;
    private readonly EventService _eventService;
    private readonly UserDataService _dataService;
    private readonly UserManager<User> _userManager;

    private readonly UserLockoutService _lockoutService;

    public ProjectsController(Context context, EventService eventService, UserDataService dataService, UserManager<User> userManager,
        UserLockoutService lockoutService)
    {
        _context = context;
        _eventService = eventService;
        _dataService = dataService;
        _userManager = userManager;
        _lockoutService = lockoutService;
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var userNameAndRank = await _dataService.GetNameAndRankAsync(userId) ?? string.Empty;
        return (userId, userNameAndRank);
    }

    public async Task<ProjectViewModel> UpdateModelAsync(ProjectViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;       
        model.SecurityCount = await _lockoutService.SecurityAsync<ProjectEvent>(model.UserId, model.Action);
        return model;
    }
}