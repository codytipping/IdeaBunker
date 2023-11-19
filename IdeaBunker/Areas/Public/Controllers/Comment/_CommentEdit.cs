using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Comment.Edit)]
public partial class CommentController : Controller
{
    public async Task<IActionResult> Edit(string id)
    {
        var model = await SetCommentViewModelAsync(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, CommentViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Action = "Edit";
            model = await UpdateModelAsync(model);
            await UpdateCommentAsync(model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}