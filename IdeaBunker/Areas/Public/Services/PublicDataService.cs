﻿using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Services;

public interface IPublicDataService 
{
    string GetCategoryName(string id);
    Task<Project> GetProjectInfoAsync(string id);
}

public class PublicDataService : IPublicDataService
{
    private readonly PublicContext _context;

    public PublicDataService(PublicContext context) { _context = context; }

    public string GetCategoryName(string id)
    {
        var categoryName = _context.Categories
            .Where(c => c.Id == id)
            .Select(c => c.Name)
            .FirstOrDefault();
        return categoryName ?? string.Empty;
    }

    public async Task<Project> GetProjectInfoAsync(string id)
    {
        var project = await _context.Projects
            .Include(p => p.Category)
            .Include(p => p.Clearance)
            .Include(p => p.User)
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project ?? new();
    }
}