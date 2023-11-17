using IdeaBunker.Areas.Public.ViewModels.Projects;
using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Area("Public")]
public partial class ProjectController : Controller
{
    private readonly Context _context;
    private readonly UserManager<User> _userManager;

    public ProjectController(Context context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        //var userNameAndRank = await _dataService.GetNameAndRankAsync(userId) ?? string.Empty;
        var userNameAndRank = string.Empty;
        return (userId, userNameAndRank);
    }

    public async Task<ProjectViewModel> UpdateModelAsync(ProjectViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        //model.SecurityCount = await _lockoutService.SecurityAsync<ProjectEvent>(model.UserId, model.Action);
        model.SecurityCount = 0; // Temp.
        return model;
    }
}