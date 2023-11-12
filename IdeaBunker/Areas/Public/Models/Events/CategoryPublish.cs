using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class CategoryPublish : Event
{
    public required Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
}