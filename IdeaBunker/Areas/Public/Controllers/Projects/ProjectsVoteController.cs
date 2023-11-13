using IdeaBunker.Data;
using IdeaBunker.Models;
using IdeaBunker.Services;
using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Vote")]
public class ProjectsVoteController : Controller
{
    private readonly Context _context;
    private readonly UserDataService _dataService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ProjectEventService _eventService;

    public ProjectsVoteController(Context context, UserDataService dataService, UserManager<User> userManager, 
        SignInManager<User> signInManager, ProjectEventService eventService)
    {
        _userManager = userManager;
        _context = context;
        _dataService = dataService;
        _signInManager = signInManager;
        _eventService = eventService;
    }

    public async Task<IActionResult> Vote(string id)
    {       
        var model = await _eventService.SetViewModelAsync(id); // Needs to be a vote view model.
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Vote(string id, ProjectVoteViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = false;
            if (viewModel.VoteType == "downvote") { result = await UpdateDownvoteCount(viewModel); }
            if (viewModel.VoteType == "upvote") { result = await UpdateUpvoteCount(viewModel); }
            if (result) { return RedirectToAction(nameof(Vote)); }
        }
        return View(viewModel);
    }

    private async Task<bool> UpdateDownvoteCount(ProjectVoteViewModel viewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var project = _context.Projects.Find(viewModel.Id) ?? new();
        var projectEvent = await _eventService.GetEventAsync(viewModel.Id, userId);
        if (projectEvent != null && projectEvent.VoteType == false) { return true; }
        if (projectEvent != null && projectEvent.VoteType == true) { project.UpvoteCount--; }
        project.DownvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        viewModel.Action = "Vote";
        var model = await TranslateViewModel(viewModel, false);
        await _eventService.SetEventAsync(model, viewModel.Id);
        return true;
    }

    private async Task<bool> UpdateUpvoteCount(ProjectVoteViewModel viewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var project = _context.Projects.Find(viewModel.Id) ?? new();
        var projectEvent = await _eventService.GetEventAsync(viewModel.Id, userId);
        if (projectEvent != null && projectEvent.VoteType == true) { return true; }
        if (projectEvent != null && projectEvent.VoteType == false) { project.DownvoteCount--; }
        project.UpvoteCount++;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        viewModel.Action = "Vote";
        var model = await TranslateViewModel(viewModel, true);
        await _eventService.SetEventAsync(model, viewModel.Id);
        return true;
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userId = user?.Id ?? string.Empty;
        var userNameAndRank = await _dataService.GetNameAndRankAsync(userId) ?? string.Empty;
        return (userId, userNameAndRank);
    }

    public async Task<ProjectViewModel> SetUserInfoAsync(ProjectViewModel viewModel)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        viewModel.UserId = userId;
        viewModel.UserNameAndRank = userNameAndRank;
        return viewModel;
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