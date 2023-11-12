using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class DocumentDownload : Event
{
    public required Guid DocumentId { get; set; }
    public required string DocumentName { get; set; }
}