namespace IdeaBunker.Models;

public class DocumentEvent : Event
{
    public required string DocumentId { get; set; }
    public required string DocumentName { get; set; }
}