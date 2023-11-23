using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaBunker.Areas.Public.Models;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Document.Upload)]
public partial class DocumentController : Controller
{
    public IActionResult Upload(string id)
    {
        DocumentViewModel model = new() { ProjectId = id, };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(DocumentViewModel model)
    {
        if (ModelState.IsValid
            && model.UploadedDocument != null && model.UploadedDocument.Length > 0)
        {
            byte[] fileData;
            using (var memoryStream = new MemoryStream())
            {
                model.UploadedDocument.CopyTo(memoryStream);
                fileData = memoryStream.ToArray();
            }
            model = await UpdateModelAsync(model);
            await AddDocumentAsync(model, fileData);
            return RedirectToAction("Details", "Project", new { id = model.ProjectId, });
        }
        return View(model);
    }
}