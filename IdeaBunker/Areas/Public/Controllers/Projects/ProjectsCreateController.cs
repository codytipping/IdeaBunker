using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Create")]
public partial class ProjectsController
{
    public IActionResult Create()
    {
        ProjectViewModel model = new();
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Action = "Create";
            model = await UpdateModelAsync(model);
            await _eventService.SetProjectAsync(model);
            return RedirectToAction(nameof(Index), "ProjectsUnpublished");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        return View(model);
    }
}