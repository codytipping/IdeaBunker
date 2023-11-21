using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Comment.Delete)]
public partial class CommentController : Controller
{
    public async Task<IActionResult> Delete(string id)
    {
        var model = await SetCommentViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id, CommentViewModel model)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment is not null)
        {
            model.Action = "Delete";
            model = await UpdateModelAsync(model);
            await SetCommentEventAsync(model, id);
            _context.Comments.Remove(comment);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}