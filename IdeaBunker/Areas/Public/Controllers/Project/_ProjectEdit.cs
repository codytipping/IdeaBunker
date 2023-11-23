using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Areas.Public.ViewModels;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Project.Edit)]
public partial class ProjectController : Controller
{
    public async Task<IActionResult> Edit(string id)
    {
        var model = await SetProjectViewModelAsync(id);
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        ViewData["StatusId"] = new SelectList(_context.ProjectsStatus, "Id", "Name", model.StatusId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, ProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            model = await UpdateModelAsync(model);
            await UpdateProjectAsync(model);
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        ViewData["StatusId"] = new SelectList(_context.ProjectsStatus, "Id", "Name", model.StatusId);
        return View(model);
    }
}