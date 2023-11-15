namespace IdeaBunker.Models;

public class ProjectStatus : Enum
{
    public virtual ICollection<Project>? Projects { get; set; }
}