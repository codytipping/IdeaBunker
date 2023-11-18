using IdeaBunker.Areas.Public.ViewModels.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = "Permissions.Projects.View")]
public partial class ProjectController : Controller
{
    public async Task<IActionResult> Details(string id)
    {
        var project = await GetProjectInfoAsync(id);
        var userNameAndRank = await GetNameAndRankAsync();
        ProjectDetailsViewModel projectViewModel = new()
        {
            Id = project!.Id,
            Name = project!.Name,
            UserNameAndRank = userNameAndRank,
            Description = project!.Description,
            CategoryDescription = $"{project?.Category?.Name}: {project?.Category?.Description}",
            ClearanceDescription = $"{project?.Clearance?.Name}: {project?.Clearance?.Description}",
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",
        };
        return View(projectViewModel);
    }

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