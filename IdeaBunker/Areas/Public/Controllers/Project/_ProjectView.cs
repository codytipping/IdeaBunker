﻿using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Project.View)]
public partial class ProjectController : Controller
{
    public async Task<IActionResult> Details(string id)
    {
        var model = await SetProjectDetailsViewModelAsync(id);
        return View(model);
    }

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
}