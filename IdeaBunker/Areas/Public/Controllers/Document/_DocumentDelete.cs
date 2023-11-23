using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Document.Delete)]
public partial class DocumentController : Controller
{
    public async Task<IActionResult> Delete(string id)
    {
        var model = await SetDocumentDetailsViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id, DocumentViewModel model)
    {
        var document = await _context.Documents.FindAsync(id);
        if (document is not null)
        {
            model = await UpdateModelAsync(model);
            _context.Documents.Remove(document);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}