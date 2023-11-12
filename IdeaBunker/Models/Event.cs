using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Event
{
    [Key]
    public required Guid Id { get; set; }
    public required string UserId { get; set; }
    public required string UserNameAndRank { get; set; }
    public required int SecurityCount { get; set; } = 0;

    [StringLength(1000)]
    public required string Description { get; set; }

    [DataType(DataType.DateTime)]
    public required DateTime Date { get; set; } = DateTime.Now;
}