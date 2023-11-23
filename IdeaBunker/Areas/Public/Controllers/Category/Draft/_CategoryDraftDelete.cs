using IdeaBunker.Areas.Public.ViewModels;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Category.Create)]
public partial class CategoryDraftController : Controller
{
    public async Task<IActionResult> Delete(string id)
    {
        var model = await SetCategoryDetailsViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id, CategoryViewModel model)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is not null)
        {
            model = await UpdateModelAsync(model);
            _context.Categories.Remove(category);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}