namespace IdeaBunker.Models;

public class StatusProjectTask : Enum
{
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
}