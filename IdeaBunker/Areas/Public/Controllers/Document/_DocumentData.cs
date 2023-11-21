using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaBunker.Areas.Public.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class DocumentController : Controller
{
    public string GetDocumentName(string id)
    {
        return _context.Documents.Where(d => d.Id == id).Select(d => d.Name).FirstOrDefault()!;
    }

    public string GetProjectName(string id)
    {
        return _context.Projects.Where(p => p.Id == id).Select(p => p.Name).FirstOrDefault()!;
    }

    public async Task<IList<Document>> GetDocumentsAsync(string id)
    {
        var documents = await _context.Documents
            .Where(d => d.Project != null && d.ProjectId == id)
            .Include(d => d.Project)
            .ToListAsync();
        return documents!;
    }

    public async Task<Document> GetDocumentInfoAsync(string id)
    {
        var document = await _context.Documents.Include(d => d.Project).FirstOrDefaultAsync(d => d.Id == id);
        return document!;
    }
}