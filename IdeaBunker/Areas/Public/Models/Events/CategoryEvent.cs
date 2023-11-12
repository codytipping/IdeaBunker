namespace IdeaBunker.Models;

public class CategoryEvent : Event
{
    public required string CategoryId { get; set; }
    public required string CategoryName { get; set; }
}