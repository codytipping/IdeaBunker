using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Category.Create)]
public partial class CategoryDraftController : Controller
{
    public async Task<IActionResult> Edit(string id)
    {
        var model = await SetCategoryViewModelAsync(id);
        ViewData["StatusId"] = new SelectList(_context.ProjectsStatus, "Id", "Name", model.StatusId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, CategoryViewModel model)
    {
        if (ModelState.IsValid)
        {
            model = await UpdateModelAsync(model);
            await UpdateCategoryAsync(model);
            return RedirectToAction(nameof(Index));
        }
        ViewData["StatusId"] = new SelectList(_context.ProjectsStatus, "Id", "Name", model.StatusId);
        return View(model);
    }
}