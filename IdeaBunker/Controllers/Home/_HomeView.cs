using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Controllers;

public partial class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await GetProjectsAsync();
        var models = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            var model = await SetProjectViewModelAsync(project.Id);
            models.Add(model);
        }
        return View(models);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}