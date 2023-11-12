using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Data;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Areas.Public.Services;

public interface IPublicDataService 
{
    public string GetCategoryName(string id);
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
}