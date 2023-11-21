using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Document.View)]
public partial class DocumentController : Controller
{
    public async Task<IActionResult> Details(string id)
    {
        var model = await SetDocumentDetailsViewModelAsync(id);
        return View(model);
    }

    public async Task<IActionResult> Index(string id)
    {
        var documents = await GetDocumentsAsync(id);
        var models = new List<DocumentViewModel>();
        foreach (var document in documents)
        {
            var model = await SetDocumentViewModelAsync(document.Id);
            models.Add(model);
        }
        return View(models);
    }
}