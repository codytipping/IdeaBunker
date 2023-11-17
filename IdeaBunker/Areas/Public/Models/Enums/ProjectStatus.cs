namespace IdeaBunker.Areas.Public.Models;

public class ProjectStatus : IdeaBunker.Models.Enum
{
    public virtual ICollection<Project>? Projects { get; set; }
}