using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Services;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IdeaBunker.Areas.Public.Controllers.Projects;

public class ProjectsController : Controller
{
    private readonly PublicContext _context;
    private readonly ProjectEventService _eventService;
    private readonly UserDataService _dataService;

    public ProjectsController(PublicContext context, ProjectEventService eventService, UserDataService dataService)
    {
        _context = context;
        _eventService = eventService;
        _dataService = dataService;
    }

    [Authorize(Policy = "Permissions.Projects.Create")]
    public IActionResult Create()
    {
        ProjectViewModel viewModel = new();
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Create")]
    public async Task<IActionResult> Create(ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.Action = "Create";
            await _eventService.SetProjectAsync(viewModel);                       
            return RedirectToAction(nameof(Index), "ProjectsUnpublished");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        return View(viewModel);
    }

    [Authorize(Policy = "Permissions.Projects.Delete")]
    public async Task<IActionResult> Delete(string id)
    {
        var project = await _context.Projects.FindAsync(id) ?? new();
        var viewModel = _eventService.SetProjectViewModel(project);
        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id, ProjectViewModel projectViewModel)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
        {
            await _eventService.SetEventAsync(projectViewModel, id);
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
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",S
        };
        return View(projectViewModel);
    }

    [Authorize(Policy = "Permissions.Projects.Edit")]
    public async Task<IActionResult> Edit(string id)
    {
        var project = await _eventService.GetProjectInfoAsync(id);
        var viewModel = _eventService.SetProjectViewModel(project);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        ViewData["ClearanceId"] = new SelectList(_context.Clearances, "Id", "Name", viewModel.ClearanceId);
        ViewData["StatusId"] = new SelectList(_context.StatusProjects, "Id", "Name", viewModel.StatusId);
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Edit")]
    public async Task<IActionResult> Edit(string id, ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _eventService.UpdateProjectAsync(viewModel);                     
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        ViewData["ClearanceId"] = new SelectList(_context.Clearances, "Id", "Name", viewModel.ClearanceId);
        ViewData["StatusId"] = new SelectList(_context.StatusProjects, "Id", "Name", viewModel.StatusId);
        return View(viewModel);
    }
}