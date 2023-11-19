using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Comment.Create)]
public partial class CommentController : Controller
{
    public IActionResult Create(string id)
    {
        CommentViewModel model = new() { ProjectId = id };        
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CommentViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Action = "Create";
            model = await UpdateModelAsync(model);
            await AddCommentAsync(model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}