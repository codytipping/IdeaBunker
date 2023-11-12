using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class TeamEvent : Event
{
    public required Guid TeamId { get; set; }
    public required string TeamName { get; set; }
    public Guid? ClaimantId { get; set; } = Guid.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}
