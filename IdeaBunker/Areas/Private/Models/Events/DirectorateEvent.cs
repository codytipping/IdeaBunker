namespace IdeaBunker.Models;

public class DirectorateEvent : Event
{
    public required string DirectorateId { get; set; }
    public required string DirectorateName { get; set; }
    public string? ClaimantId { get; set; } = string.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}