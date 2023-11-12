using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class CategoryEvent : Event
{
    public required string CategoryId { get; set; }
    public required string CategoryName { get; set; }
}