﻿using IdeaBunker.Areas.Public.ViewModels.Projects;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = "Permissions.Projects.View")]
public partial class ProjectController
{
    public async Task<IActionResult> Details(string id)
    {
        var project = await _context.Projects.FindAsync(id);
        //var userNameAndRank = await _dataService.GetNameAndRankAsync(project?.UserId ?? string.Empty);
        var userNameAndRank = string.Empty; // temp.
        ProjectDetailsViewModel projectViewModel = new()
        {
            Id = project?.Id ?? string.Empty,
            Name = project?.Name ?? string.Empty,
            UserNameAndRank = userNameAndRank,
            Description = project?.Description ?? string.Empty,
            CategoryDescription = $"{project?.Category?.Name}: {project?.Category?.Description}",
            ClearanceDescription = $"{project?.Clearance?.Name}: {project?.Clearance?.Description}",
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",
        };
        return View(projectViewModel);
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        /*var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name != "Unpublished")
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .ToListAsync();
        */
        var projects = await _context.Projects.ToListAsync();
        var projectViewModels = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            ProjectViewModel viewModel = new()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CategoryName = project?.Category?.Name ?? string.Empty,
                ClearanceName = project?.Clearance?.Name ?? string.Empty,
                StatusName = project?.Status?.Name ?? string.Empty,
            };
            //var viewModel = await _eventService.SetProjectViewModelAsync(project.Id);
            projectViewModels.Add(viewModel);
        }
        return View(projectViewModels);
    }
}