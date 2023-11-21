using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Areas.Public.ViewModels;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Project.Delete)]
public partial class ProjectController : Controller
{
    public async Task<IActionResult> Delete(string id)
    {
        var model = await SetProjectDetailsViewModelAsync(id);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id, ProjectViewModel model)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is not null)
        {
            model.Action = "Delete";
            model = await UpdateModelAsync(model);
            await SetProjectEventAsync(model, id);
            _context.Projects.Remove(project);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}