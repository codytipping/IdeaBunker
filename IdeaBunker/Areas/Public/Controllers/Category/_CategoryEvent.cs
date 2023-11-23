using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Controllers;

public partial class CategoryController : Controller
{
    public async Task AddCategoryAsync(CategoryViewModel model)
    {
        model ??= new();
        Category category = new()
        {
            Name = model.Name,
            Description = model.Description,
            StatusId = model.StatusId!,
            UserId = model.UserId,
        };
        _context.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task<CategoryViewModel> SetCategoryViewModelAsync(string id)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id)!;
        CategoryViewModel model = new()
        {
            Id = category!.Id,
            Name = category.Name,
            Description = category.Description,
            StatusName = GetStatusName(category.StatusId!),
        };
        return model;
    }

    public async Task<CategoryDetailsViewModel> SetCategoryDetailsViewModelAsync(string id)
    {
        var category = await GetCategoryInfoAsync(id)!;
        CategoryDetailsViewModel model = new()
        {
            Id = category!.Id,
            Name = category!.Name,
            UserNameAndRank = await GetNameAndRankAsync(category.UserId!),
            Description = category!.Description,          
            StatusDescription = $"{category?.Status?.Name}: {category?.Status?.Description}",
        };
        return model;
    }

    public async Task UpdateCategoryAsync(CategoryViewModel model)
    {
        model ??= new();
        Category category = new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            StatusId = model.StatusId,
            UserId = model.UserId,
        };
        _context.Update(category);
        await _context.SaveChangesAsync();
    }
}