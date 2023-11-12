using IdeaBunker.Areas.Private.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Enums;

public class StatusProjectTask : IdeaBunker.Models.Enum
{
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
}