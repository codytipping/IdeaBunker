using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdeaBunker.Areas.Public.Models;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = "Permissions.Projects.Vote")]
public partial class ProjectController : Controller
{
    public async Task<IActionResult> Vote(string id)
    {
        var model = await SetProjectVoteViewModelAsync(id); 
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Vote(string id, ProjectVoteViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = false;
            if (model.VoteType == "downvote") { result = await UpdateDownvoteCount(model); }
            if (model.VoteType == "upvote") { result = await UpdateUpvoteCount(model); }
            if (result) { return RedirectToAction(nameof(Vote)); }
        }
        return View(model);
    }

    private async Task<bool> UpdateDownvoteCount(ProjectVoteViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var project = _context.Projects.FirstOrDefault(p => p.Id == model.Id)!;
        var projectEvent = await GetProjectEventAsync(user!.Id, model.Id, "Vote");
        if (projectEvent != null && projectEvent.VoteType == false) { return true; }
        if (projectEvent != null && projectEvent.VoteType == true) { project.UpvoteCount--; }
        project.DownvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        var viewModel = await TranslateViewModel(model, false);
        await SetProjectEventAsync(viewModel, viewModel.Id);
        return true;
    }

    private async Task<bool> UpdateUpvoteCount(ProjectVoteViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var project = _context.Projects.FirstOrDefault(p => p.Id == model.Id)!;
        var projectEvent = await GetProjectEventAsync(user!.Id, model.Id, "Vote");
        if (projectEvent != null && projectEvent.VoteType == true) { return true; }
        if (projectEvent != null && projectEvent.VoteType == false) { project.DownvoteCount--; }
        project.UpvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        var viewModel = await TranslateViewModel(model, true);
        await SetProjectEventAsync(viewModel, viewModel.Id);
        return true;
    }

    private async Task<ProjectVoteViewModel> SetProjectVoteViewModelAsync(string id)
    {
        var project = await _context.Projects.FindAsync(id)!;
        ProjectVoteViewModel model = new()
        {
            Id = project!.Id,
            Name = project.Name,
            Description = project.Description,
            UpvoteCount = project.UpvoteCount,
            DownvoteCount = project.DownvoteCount,
        };
        return model;
    }

    private async Task<ProjectViewModel> TranslateViewModel(ProjectVoteViewModel viewModel, bool vote)
    {
        viewModel.Action = "Vote";
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        ProjectViewModel model = new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Action = viewModel.Action,
            VoteType = vote,
            UserId = userId,
            UserNameAndRank = userNameAndRank,
            Description = viewModel.Description,
            EventDescription = viewModel.EventDescription,
        };
        return model;
    }
}