using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class DocumentEvent : Event
{
    public required string DocumentId { get; set; }
    public required string DocumentName { get; set; }
}