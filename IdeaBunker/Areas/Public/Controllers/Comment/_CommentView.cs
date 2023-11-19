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
        var viewModels = new List<CommentViewModel>();
        foreach (var comment in comments)
        {
            var viewModel = await SetCommentViewModelAsync(comment.Id);
            viewModels.Add(viewModel);
        }
        return View(viewModels);
    }
}