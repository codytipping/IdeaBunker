using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models;

public class ProjectEvent : Event
{
    public required string ProjectId { get; set; }
    public required string ProjectName { get; set; }
    public bool? VoteType { get; set; } = null;
}