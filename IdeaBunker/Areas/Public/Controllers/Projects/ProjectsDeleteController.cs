using IdeaBunker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeaBunker.Controllers;

[Authorize(Policy = "Permissions.Projects.Delete")]
public partial class ProjectsController
{
    public async Task<IActionResult> Delete(string id)
    {
        var model = await _eventService.SetProjectViewModelAsync(id);
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
            await _eventService.SetProjectEventAsync(model, id);
            _context.Projects.Remove(project);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}