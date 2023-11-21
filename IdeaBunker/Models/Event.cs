using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Event
{
    [Key]
    public string Id { get; set; }
    public required string Action { get; set; }
    public required string UserId { get; set; }
    public required string UserNameAndRank { get; set; }
    public string? EventDescription { get; set; }
    public required int SecurityCount { get; set; } = 0;

    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;

    public Event()
    {
        Id = Guid.NewGuid().ToString();
    }
}