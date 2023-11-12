using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class DocumentDelete : Event
{
    public required Guid DocumentId { get; set; }
    public required string DocumentName { get; set; }
}