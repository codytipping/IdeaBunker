using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class CategoryCreate : Event
{
    public required Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }    
}