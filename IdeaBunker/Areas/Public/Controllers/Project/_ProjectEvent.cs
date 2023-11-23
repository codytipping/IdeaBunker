using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectController : Controller
{
    public async Task<ProjectEvent?> GetProjectEventAsync(string userId, string projectId, string action)
    {
        var projectEvent = await _context.ProjectsEvent
            .Where(p => p.UserId == userId && p.ProjectId == projectId && p.Action == action)
            .OrderByDescending(p => p.Date)
            .FirstOrDefaultAsync();
        return projectEvent;
    }

    public async Task AddProjectAsync(ProjectViewModel model)
    {
        model ??= new();        
        Project project = new()
        {
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task<CommentViewModel> SetCommentViewModelAsync(string id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id)!;
        CommentViewModel model = new()
        {
            Id = comment!.Id,
            ProjectId = comment.ProjectId,
            Name = GetProjectName(comment.ProjectId),
            Description = comment.Description,
            Date = comment.Date,
            UserId = comment.UserId,
            UserNameAndRank = await GetNameAndRankAsync(comment.UserId),
        };
        return model;
    }

    public async Task<DocumentViewModel> SetDocumentViewModelAsync(string id)
    {
        var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id)!;
        DocumentViewModel model = new()
        {
            Id = document!.Id,
            ProjectId = document.ProjectId,
            Name = document!.Name,
            Description = document.Description,
            UserId = document.UserId,
            UserNameAndRank = await GetNameAndRankAsync(document.UserId),
        };
        return model;
    }

    public async Task<ProjectViewModel> SetProjectViewModelAsync(string id)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id)!;
        ProjectViewModel model = new()
        {
            Id = project!.Id,
            Name = project.Name,
            Description = project.Description,
            UpvoteCount = project.UpvoteCount,
            DownvoteCount = project.DownvoteCount,
            CategoryName = GetCategoryName(project!.CategoryId),
            StatusName = GetStatusName(project!.StatusId),          
        };
        return model;
    }

    public async Task<ProjectDetailsViewModel> SetProjectDetailsViewModelAsync(string id)
    {
        var project = await GetProjectInfoAsync(id)!;
        ProjectDetailsViewModel model = new()
        {
            Id = project!.Id,
            Name = project!.Name,
            Description = project!.Description,
            CategoryDescription = $"{project?.Category?.Name}: {project?.Category?.Description}",
            StatusDescription = $"{project?.Status?.Name}: {project?.Status?.Description}",            
            Comment = new() { ProjectId = project!.Id },
            Document = new() { ProjectId = project!.Id },
            Comments = await GetCommentViewModelsAsync(project!.Id),
            Documents = await GetDocumentViewModelsAsync(project!.Id),
            UserNameAndRank = await GetNameAndRankAsync(project!.UserId),
        };
        return model;
    }

    public async Task UpdateProjectAsync(ProjectViewModel model)
    {
        model ??= new();
        Project project = new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            CategoryId = model.CategoryId,
            StatusId = model.StatusId,
            UserId = model.UserId,
            UpvoteCount = model.UpvoteCount,
            DownvoteCount = model.DownvoteCount,
        };
        _context.Update(project);
        await _context.SaveChangesAsync();
    }
}