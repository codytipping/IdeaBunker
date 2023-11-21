using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Category.View)]
public partial class CategoryController : Controller
{
    public async Task<IActionResult> Details(string id)
    {
        var model = await SetCategoryDetailsViewModelAsync(id);
        return View(model);
    }

    public async Task<IActionResult> Index()
    {
        var projects = await GetCategoriesAsync();
        var models = new List<CategoryViewModel>();
        foreach (var project in projects)
        {
            var model = await SetCategoryViewModelAsync(project.Id);
            models.Add(model);
        }
        return View(models);
    }
}