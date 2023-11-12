using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class ProjectTask : Entity
{
    public int? UpvoteCount { get; set; }
    public int? DownvoteCount { get; set; }

    [ForeignKey("Project")]
    public required string ProjectId { get; set; }
    public required virtual Project Project { get; set; }

    [ForeignKey("Status")]
    public required string StatusId { get; set; }
    public required virtual StatusProjectTask Status { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public required virtual User User { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}