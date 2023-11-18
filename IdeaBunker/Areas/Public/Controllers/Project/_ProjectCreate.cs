using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Areas.Public.ViewModels.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = "Permissions.Projects.Create")]
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
            model.Action = "Create";
            model = await UpdateModelAsync(model);
            model.ClearanceId = GetClearanceId("No Clearance");
            model.StatusId = GetStatusId("Unpublished");           
            await AddProjectAsync(model);
            return RedirectToAction(nameof(Index), "ProjectDraft");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
        return View(model);
    }
}