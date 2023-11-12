using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class DivisionEvent : Event
{
    public required Guid DivisionId { get; set; }
    public required string DivisionName { get; set; }
    public Guid? ClaimantId { get; set; } = Guid.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}
