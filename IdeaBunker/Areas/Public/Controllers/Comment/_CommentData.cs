using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class CommentController : Controller
{
    public string GetProjectName(string id)
    {
        return _context.Projects.Where(p => p.Id == id).Select(p => p.Name).FirstOrDefault()!;
    }

    public async Task<IList<Comment>> GetCommentsAsync(string id)
    {
        var comments = await _context.Comments.Where(c => c.ProjectId == id).ToListAsync();
        return comments!;
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

    public async Task<CommentViewModel> UpdateModelAsync(CommentViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        return model;
    }
}