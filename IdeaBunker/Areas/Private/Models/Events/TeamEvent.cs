using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class TeamEvent : Event
{
    public required string TeamId { get; set; }
    public required string TeamName { get; set; }
    public string? ClaimantId { get; set; } = string.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}