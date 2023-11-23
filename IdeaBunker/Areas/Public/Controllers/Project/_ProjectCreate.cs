using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Areas.Public.ViewModels;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Project.Create)]
public partial class ProjectController : Controller
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
            model = await UpdateModelAsync(model);
            model.StatusId = GetStatusId("Unpublished");           
            await AddProjectAsync(model);
            return RedirectToAction(nameof(CreateEvent));
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        return View(model);
    }

    public IActionResult CreateEvent()
    {
        ProjectViewModel model = new();
        model.Event!.ShowModal = true;
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View("Create", model);
    }
}