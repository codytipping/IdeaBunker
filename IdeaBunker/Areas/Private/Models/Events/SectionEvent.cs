namespace IdeaBunker.Models;

public class SectionEvent : Event
{
    public required string SectionId { get; set; }
    public required string SectionName { get; set; }
    public string? ClaimantId { get; set; } = string.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}