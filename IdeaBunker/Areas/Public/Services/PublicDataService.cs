using IdeaBunker.Areas.Public.Data;

namespace IdeaBunker.Services;

public interface IPublicDataService 
{
    string GetCategoryName(string id);
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