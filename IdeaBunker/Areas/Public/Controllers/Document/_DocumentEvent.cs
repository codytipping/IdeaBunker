using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaBunker.Areas.Public.Models;
using Microsoft.EntityFrameworkCore;
using IdeaBunker.Areas.Public.Models.Events;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class DocumentController : Controller
{
    public async Task AddDocumentAsync(DocumentViewModel model, byte[] fileData)
    {
        Document document = new()
        {
            Name = model.Name,
            Description = model.Description,
            UserId = model.UserId,
            ProjectId = model.ProjectId!,
            Path = model.UploadedDocument!.FileName,
            Mime = model.UploadedDocument!.ContentType,
            Data = fileData,
        };
        _context.Add(document);
        await _context.SaveChangesAsync();
        await SetDocumentEventAsync(model);
    }

    public async Task<string> GetNameAndRankAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var rankName = _context.Ranks
            .Where(r => user != null && r.Id == user.RankId)
            .Select(r => r.Name)
            .FirstOrDefault();
        return $"{user!.FirstName} {user.LastName}, {rankName}";
    }

    public async Task<(string UserId, string UserNameAndRank)> GetUserInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        var userNameAndRank = await GetNameAndRankAsync(user!.Id)!;
        return (user!.Id, userNameAndRank);
    }

    public async Task<DocumentViewModel> SetDocumentViewModelAsync(string id)
    {
        var document = await _context.Documents.FirstOrDefaultAsync(d => d.Id == id)!;
        DocumentViewModel model = new()
        {
            Id = document!.Id,
            Name = document.Name,
            Description = document.Description,
            ProjectName = GetProjectName(document.ProjectId),
        };
        return model;
    }

    public async Task<DocumentDetailsViewModel> SetDocumentDetailsViewModelAsync(string id)
    {
        var document = await GetDocumentInfoAsync(id)!;
        DocumentDetailsViewModel model = new()
        {
            Id = document!.Id,
            Name = document!.Name,
            UserNameAndRank = await GetNameAndRankAsync(document.UserId!),
            Description = document!.Description,
            ProjectDescription = $"{document?.Project?.Name}: {document?.Project?.Description}",
        };
        return model;
    }

    public async Task SetDocumentEventAsync(DocumentViewModel viewModel)
    {
        var model = viewModel!;
        DocumentEvent documentEvent = new()
        {
            DocumentId = model.Id,
            DocumentName = model.Name,
            Action = model.Action,
            UserId = model.UserId,
            UserNameAndRank = model.UserNameAndRank,
            EventDescription = model.EventDescription,
            SecurityCount = model.SecurityCount,
        };
        _context.Add(documentEvent);
        await _context.SaveChangesAsync();
    }

    public async Task<DocumentViewModel> UpdateModelAsync(DocumentViewModel model)
    {
        var (userId, userNameAndRank) = await GetUserInfoAsync();
        model.UserId = userId;
        model.UserNameAndRank = userNameAndRank;
        return model;
    }
}