namespace IdeaBunker.Models;

public class ProjectEvent : Event
{
    public required string ProjectId { get; set; }
    public required string ProjectName { get; set; }
    public bool? VoteType { get; set; } = null;
}