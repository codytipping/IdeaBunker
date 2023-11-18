using IdeaBunker.Areas.Public.ViewModels.Projects;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectDraftController : Controller
{
    public async Task<IActionResult> Index()
    {
        var projects = await GetProjectsAsync();
        var projectViewModels = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            var viewModel = await SetProjectViewModelAsync(project.Id);
            projectViewModels.Add(viewModel);
        }
        return View(projectViewModels);
    }
}