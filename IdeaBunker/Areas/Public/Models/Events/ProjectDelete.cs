namespace IdeaBunker.Areas.Public.Models.Events;

public class ProjectDelete
{
    public required Guid ProjectId { get; set; }
    public required string ProjectName { get; set; }
}
