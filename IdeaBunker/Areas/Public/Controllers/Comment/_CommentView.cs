using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Comment.View)]
public partial class CommentController : Controller
{
    public async Task<IActionResult> Index(string id)
    {
        var comments = await GetCommentsAsync(id);
        var models = new List<CommentViewModel>();
        foreach (var comment in comments)
        {
            var model = await SetCommentViewModelAsync(comment.Id);
            models.Add(model);
        }
        return View(models);
    }
}