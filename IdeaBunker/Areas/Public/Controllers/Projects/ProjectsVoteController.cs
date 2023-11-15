using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Vote")]
public partial class ProjectsController
{
    public async Task<IActionResult> Vote(string id)
    {       
        var model = await _eventService.SetProjectViewModelAsync(id); // Needs to be a vote view model.
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
        var userId = user?.Id ?? string.Empty;
        var project = _context.Projects.Find(model.Id) ?? new();
        var projectEvent = await _eventService.GetProjectEventAsync(model.Id, userId);
        if (projectEvent != null && projectEvent.VoteType == false) { return true; }
        if (projectEvent != null && projectEvent.VoteType == true) { project.UpvoteCount--; }
        project.DownvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        model.Action = "Vote";
        var newModel = await TranslateViewModel(model, false);
        await _eventService.SetProjectEventAsync(newModel, newModel.Id);
        return true;
    }

    private async Task<bool> UpdateUpvoteCount(ProjectVoteViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var project = _context.Projects.Find(model.Id) ?? new();
        var projectEvent = await _eventService.GetProjectEventAsync(model.Id, userId);
        if (projectEvent != null && projectEvent.VoteType == true) { return true; }
        if (projectEvent != null && projectEvent.VoteType == false) { project.DownvoteCount--; }
        project.UpvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        model.Action = "Vote";
        var newModel = await TranslateViewModel(model, true);
        await _eventService.SetProjectEventAsync(newModel, newModel.Id);
        return true;
    }

    public async Task<ProjectViewModel> TranslateViewModel(ProjectVoteViewModel viewModel, bool vote)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        ProjectViewModel model = new()
        {
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