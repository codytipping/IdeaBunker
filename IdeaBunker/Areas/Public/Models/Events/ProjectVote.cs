using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class ProjectVote : Event
{
    public required Guid ProjectId { get; set; }
    public required string ProjectName { get; set; }
}