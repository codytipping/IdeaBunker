using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectDraftController : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await GetProjectsAsync();
        var viewModels = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            var viewModel = await SetProjectViewModelAsync(project.Id);
            viewModels.Add(viewModel);
        }
        return View(viewModels);
    }
}