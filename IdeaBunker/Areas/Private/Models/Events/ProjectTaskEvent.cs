using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class ProjectTaskEvent : Event
{
    public required Guid ProjectTaskId { get; set; }
    public required string ProjectTaskName { get; set; }
}