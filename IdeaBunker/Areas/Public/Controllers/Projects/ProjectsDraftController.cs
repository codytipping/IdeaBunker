using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Create")]
public partial class ProjectsController
{
    public async Task<IActionResult> DeleteDraft(string id)
    {
        var model = await _eventService.SetProjectViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteDraftConfirmed(string id, ProjectViewModel model)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
        {
            model.Action = "Delete";
            model = await UpdateModelAsync(model);
            await _eventService.SetProjectEventAsync(model, id);
            _context.Projects.Remove(project);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DetailsDraft(string id)
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

    public async Task<IActionResult> EditDraft(string id)
    {
        var model = await _eventService.SetProjectViewModelAsync(id);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditDraft(string id, ProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Action = "Edit";
            model = await UpdateModelAsync(model);
            await _eventService.SetProjectAsync(model);
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);       
        return View(model);
    }

    public async Task<IActionResult> IndexDraft()
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
            var viewModel = await _eventService.SetProjectViewModelAsync(project.Id);
            projectViewModels.Add(viewModel);
        }
        return View(projectViewModels);
    }

    // NEEDS A PUBLISH METHOD (GET & POST)

}