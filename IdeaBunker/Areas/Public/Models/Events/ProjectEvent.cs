using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class ProjectEvent : Event
{
    public required string ProjectId { get; set; }
    public required string ProjectName { get; set; }
}