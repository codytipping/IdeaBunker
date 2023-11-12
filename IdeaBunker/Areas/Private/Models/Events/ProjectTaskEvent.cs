namespace IdeaBunker.Models;

public class ProjectTaskEvent : Event
{
    public required string ProjectTaskId { get; set; }
    public required string ProjectTaskName { get; set; }
}