namespace IdeaBunker.Models;

public class ProjectTaskStatus : Enum
{
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
}