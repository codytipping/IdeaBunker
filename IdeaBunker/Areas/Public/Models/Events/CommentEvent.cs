namespace IdeaBunker.Models;

public class CommentEvent : Event
{
    public required string CommentId { get; set; }
    public required string ProjectId { get; set; }
    public required string ProjectName { get; set; }
}