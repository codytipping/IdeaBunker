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

public class ProjectsController : Controller
{
    private readonly Context _context;
    private readonly ProjectEventService _eventService;
    private readonly UserDataService _dataService;
    private readonly UserManager<User> _userManager;

    public ProjectsController(Context context, ProjectEventService eventService, UserDataService dataService,
        UserManager<User> userManager)
    {
        _context = context;
        _eventService = eventService;
        _dataService = dataService;
        _userManager = userManager;
    }

    [Authorize(Policy = "Permissions.Projects.Create")]
    public IActionResult Create()
    {
        ProjectViewModel model = new();
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Create")]
    public async Task<IActionResult> Create(ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.Action = "Create";
            var model = await SetUserInfoAsync(viewModel);
            await _eventService.SetProjectAsync(model);                       
            return RedirectToAction(nameof(Index), "ProjectsUnpublished");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        return View(viewModel);
    }

    [Authorize(Policy = "Permissions.Projects.Delete")]
    public async Task<IActionResult> Delete(string id)
    {      
        var model = await _eventService.SetViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Delete")]
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

    [Authorize(Policy = "Permissions.Projects.View")]
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
            ClearanceDescription = $"{project?.Clearance?.Name}: {project?.Clearance?.Description}",
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",
        };
        return View(projectViewModel);
    }

    [Authorize(Policy = "Permissions.Projects.Edit")]
    public async Task<IActionResult> Edit(string id)
    {
        var model = await _eventService.SetViewModelAsync(id);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        ViewData["ClearanceId"] = new SelectList(_context.Clearances, "Id", "Name", model.ClearanceId);
        ViewData["StatusId"] = new SelectList(_context.StatusProjects, "Id", "Name", model.StatusId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Edit")]
    public async Task<IActionResult> Edit(string id, ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var model = await SetUserInfoAsync(viewModel);
            await _eventService.SetProjectAsync(model);                     
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        ViewData["ClearanceId"] = new SelectList(_context.Clearances, "Id", "Name", viewModel.ClearanceId);
        ViewData["StatusId"] = new SelectList(_context.StatusProjects, "Id", "Name", viewModel.StatusId);
        return View(viewModel);
    }

    [Authorize(Policy = "Permissions.Projects.View")]
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name != "Unpublished")
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