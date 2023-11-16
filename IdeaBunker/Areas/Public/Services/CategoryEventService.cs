using IdeaBunker.Models;
using IdeaBunker.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Services;


public partial interface IEventService
{
    Task<CategoryEvent?> GetCategoryEventAsync(string userId, string categoryId);
    Task SetCategoryEventAsync(CategoryViewModel model, string id);
    Task SetCategoryAsync(CategoryViewModel model);
    Task<CategoryViewModel> SetCategoryViewModelAsync(string id);
}

public partial class EventService : IEventService
{
    public async Task<CategoryEvent?> GetCategoryEventAsync(string userId, string categoryId)
    {
        var categoryEvent = await _context.CategoriesEvent
            .Where(p => p.UserId == userId && p.CategoryId == categoryId)
            .OrderByDescending(p => p.Date)
            .FirstOrDefaultAsync();
        return categoryEvent ?? null;
    }

    public async Task SetCategoryEventAsync(CategoryViewModel model, string id)
    {
        model ??= new();
        CategoryEvent categoryEvent = new()
        {
            CategoryId = id,
            CategoryName = model.Name,           
            Action = model.Action,
            UserId = model.UserId,
            UserNameAndRank = model.UserNameAndRank,
            Description = model.Description,
            EventDescription = model.EventDescription,
            SecurityCount = model.SecurityCount,
        };
        _context.Add(categoryEvent);
        await _context.SaveChangesAsync();
    }

    public async Task SetCategoryAsync(CategoryViewModel model)
    {
        model ??= new();
        Category category = new()
        {
            Name = model.Name,
            Description = model.Description,           
            StatusId = model.StatusId,
            UserId = model.UserId,           
        };
        _context.Add(model.Update ? _context.Update(category) : category);
        await _context.SaveChangesAsync();
        await SetCategoryEventAsync(model, category.Id);
    }

    public async Task<CategoryViewModel> SetCategoryViewModelAsync(string id)
    {
        var category = await _context.Categories.FindAsync(id) ?? new();
        CategoryViewModel model = new()
        {
            
        };
        return model;
    }
}
