using IdeaBunker.Areas.Public.Data;
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
    private readonly SignInManager<User> _signInManager;       

    public ProjectsController(PublicContext context, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _context = context;
        _signInManager = signInManager;
    }

    [Authorize(Policy = "Permissions.Projects.Create")]
    public IActionResult Create()
    {
        ProjectViewModel viewModel = new();
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return View(viewModel);
    }

    /*
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Permissions.Projects.Create")]
    public async Task<IActionResult> Create(ProjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var projectId = Guid.NewGuid();
            Project project = new()
            {
                Id = projectId,
                Name = projectViewModel.Name,
                Description = projectViewModel.ProjectDescription,
                UserId = projectViewModel.UserId,
                CategoryId = projectViewModel.CategoryId,
                ClearanceId = projectViewModel.ClearanceId,
                StatusId = projectViewModel.StatusId,
            };
            var (userId, userName) = await GetUserDataAsync();
            var securityCount = await _userLockoutService.GetSecurityCountAsync<ProjectCreate>(userId);
            ProjectCreate projectCreate = new()
            {
                Id = Guid.NewGuid(),
                UserId = userId ?? string.Empty,
                UserName = userName ?? string.Empty,
                ProjectId = projectId,
                ProjectName = projectViewModel.Name ?? string.Empty,
                // Add Clearance Area later.
                Description = projectViewModel.EventDescription ?? string.Empty,
                SecurityCount = securityCount,
            };
            _context.Add(projectCreate);
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "ProjectsUnpublished");
        }
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", projectViewModel.CategoryId);
        return View(projectViewModel);
    }
    */
}