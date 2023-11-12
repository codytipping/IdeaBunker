using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Events;

public class ProjectTaskEvent : Event
{
    public required string ProjectTaskId { get; set; }
    public required string ProjectTaskName { get; set; }
}