using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Services;
using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdeaBunker.Areas.Public.Controllers.Projects;

public class ProjectsController : Controller
{
    private readonly PublicContext _context;
    private readonly UserManager<User> _userManager;
    private readonly ProjectEventService _eventService;

    public ProjectsController(PublicContext context, UserManager<User> userManager, ProjectEventService eventService)
    {
        _context = context;
        _userManager = userManager;
        _eventService = eventService;
    }

    [Authorize(Policy = "Permissions.Projects.Create")]
    public IActionResult Create()
    {
        ProjectViewModel viewModel = new();
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Create")]
    public async Task<IActionResult> Create(ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.Action = "Create";
            await _eventService.SetProjectAsync(viewModel);                       
            return RedirectToAction(nameof(Index), "ProjectsUnpublished");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
        return View(viewModel);
    }
}