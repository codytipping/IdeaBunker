using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class DirectorateEvent : Event
{
    public required Guid DirectorateId { get; set; }
    public required string DirectorateName { get; set; }
    public Guid? ClaimantId { get; set; } = Guid.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}