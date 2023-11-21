using IdeaBunker.Areas.Public.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdeaBunker.Areas.Public.ViewModels;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class ProjectController : Controller
{
    public string GetCategoryName(string id)
    {
        return _context.Categories.Where(c => c.Id == id).Select(c => c.Name).FirstOrDefault()!;
    }

    public string GetProjectName(string id)
    {
        return _context.Projects.Where(p => p.Id == id).Select(p => p.Name).FirstOrDefault()!;
    }

    public string GetStatusId(string name)
    {
        return _context.ProjectsStatus.Where(s => s.Name == name).Select(s => s.Id).FirstOrDefault()!;
    }

    public string GetStatusName(string id)
    {
        return _context.ProjectsStatus.Where(s => s.Id == id).Select(s => s.Name).FirstOrDefault()!;
    }

    public async Task<IList<Comment>> GetCommentsAsync(string id)
    {
        var comments = await _context.Comments.Where(c => c.ProjectId == id).ToListAsync();
        return comments!;
    }

    public async Task<IList<Document>> GetDocumentsAsync(string id)
    {
        var documents = await _context.Documents.Where(d => d.ProjectId == id).ToListAsync();
        return documents!;
    }

    public async Task<IList<CommentViewModel>> GetCommentViewModelsAsync(string id)
    {
        var comments = await GetCommentsAsync(id);
        var models = new List<CommentViewModel>();
        foreach (var comment in comments)
        {
            var model = await SetCommentViewModelAsync(comment.Id);
            models.Add(model);
        }
        return models;
    }

    public async Task<IList<DocumentViewModel>> GetDocumentViewModelsAsync(string id)
    {
        var documents = await GetDocumentsAsync(id);
        var models = new List<DocumentViewModel>();
        foreach (var document in documents)
        {
            var model = await SetDocumentViewModelAsync(document.Id);
            models.Add(model);
        }
        return models;
    }

    public async Task<Project> GetProjectInfoAsync(string id)
    {
        var project = await _context.Projects
            .Include(p => p.Category)
            .Include(p => p.User)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project!;
    }

    public async Task<IList<Project>> GetProjectsAsync()
    {
        var projects = await _context.Projects
            .Where(p => p.Status != null && p.Status.Name != "Unpublished")
            .Include(p => p.Category)
            .Include(p => p.User)
            .Include(p => p.Status)
            .ToListAsync();
        return projects!;
    }

    public async Task<string> GetNameAndRankAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return $"{user!.FirstName} {user.LastName}, {rankName}";
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userNameAndRank = await GetNameAndRankAsync(user!.Id)!;
        return (user!.Id, userNameAndRank);
    }

    public async Task<ProjectViewModel> UpdateModelAsync(ProjectViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        return model;
    }
}