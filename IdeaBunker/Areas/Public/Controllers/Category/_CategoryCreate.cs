using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = "Permissions.Categories.Create")]
public partial class CategoryController : Controller
{
    public IActionResult Create()
    {
        CategoryViewModel model = new();      
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Action = "Create";
            model = await UpdateModelAsync(model);
            model.StatusId = GetStatusId("Unpublished");
            await AddCategoryAsync(model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}