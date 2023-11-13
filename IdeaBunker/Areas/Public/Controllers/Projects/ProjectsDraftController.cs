using IdeaBunker.Data;
using IdeaBunker.Models;
using IdeaBunker.Services;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Create")]
public class ProjectsDraftController : Controller
{
    private readonly Context _context;
    private readonly ProjectEventService _eventService;
    private readonly UserDataService _dataService;
    private readonly UserManager<User> _userManager;

    public ProjectsDraftController(Context context, ProjectEventService eventService, UserDataService dataService,
        UserManager<User> userManager)
    {
        _context = context;
        _eventService = eventService;
        _dataService = dataService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Delete(string id)
    {
        var model = await _eventService.SetViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id, ProjectViewModel viewModel)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
        {
            var model = await SetUserInfoAsync(viewModel);
            await _eventService.SetEventAsync(model, id);
            _context.Projects.Remove(project);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(string id)
    {
        var project = await _context.Projects.FindAsync(id);
        var userNameAndRank = await _dataService.GetNameAndRankAsync(project?.UserId ?? string.Empty);
        ProjectDetailsViewModel projectViewModel = new()
        {
            Id = project?.Id ?? string.Empty,
            Name = project?.Name ?? string.Empty,
            UserNameAndRank = userNameAndRank,
            Description = project?.Description ?? string.Empty,
            CategoryDescription = $"{project?.Category?.Name}: {project?.Category?.Description}",         
        };
        return View(projectViewModel);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var model = await _eventService.SetViewModelAsync(id);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var model = await SetUserInfoAsync(viewModel);
            await _eventService.SetProjectAsync(model);
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);       
        return View(viewModel);
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name == "Unpublished" && p.UserId == userId)
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .ToListAsync();
        var projectViewModels = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            var viewModel = await _eventService.SetViewModelAsync(project.Id);
            projectViewModels.Add(viewModel);
        }
        return View(projectViewModels);
    }

    // NEEDS A PUBLISH METHOD (GET & POST)

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var userNameAndRank = await _dataService.GetNameAndRankAsync(userId) ?? string.Empty;
        return (userId, userNameAndRank);
    }

    public async Task<ProjectViewModel> SetUserInfoAsync(ProjectViewModel viewModel)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        viewModel.UserId = userId;
        viewModel.UserNameAndRank = userNameAndRank;
        return viewModel;
    }
}
