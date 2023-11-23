using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;


public partial class CommentController : Controller
{
    public async Task AddCommentAsync(CommentViewModel model)
    {
        model ??= new();
        Comment comment = new()
        {
            Name = model.Name,
            Description = model.Description,
            UserId = model.UserId,
            ProjectId = model.ProjectId!,
        };
        _context.Add(comment);
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
        };
        return model;
    }

    public async Task UpdateCommentAsync(CommentViewModel model)
    {
        Comment comment = new()
        {
            Id = model.Id,
            ProjectId = model.ProjectId!,
            Name = model.Name,
            Description = model.Description,
            UserId = model.UserId,
        };
        _context.Update(comment);
        await _context.SaveChangesAsync();
    }
}