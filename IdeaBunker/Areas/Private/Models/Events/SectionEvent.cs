using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class SectionEvent : Event
{
    public required Guid SectionId { get; set; }
    public required string SectionName { get; set; }
    public Guid? ClaimantId { get; set; } = Guid.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}
