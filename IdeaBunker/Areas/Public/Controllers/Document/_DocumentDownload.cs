using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

[Authorize(Policy = PermissionsMaster.Document.Download)]
public partial class DocumentController : Controller
{
    public async Task<IActionResult> Download(string id)
    {
        var document = await GetDocumentInfoAsync(id);
        byte[] data = document.Data;
        string mime = document.Mime;
        var model = await SetDocumentViewModelAsync(document.Id);
        model = await UpdateModelAsync(model);
        return new FileContentResult(data, mime) { FileDownloadName = $"{document.Path}" };
    }
}