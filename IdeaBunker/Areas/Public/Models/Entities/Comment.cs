using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Comment : Entity
{   
    [ForeignKey("Project")]
    public required string ProjectId { get; set; }
    public required virtual Project Project { get; set; }

    [ForeignKey("ProjectTask")]
    public required string ProjectTaskId { get; set; }
    public required virtual ProjectTask ProjectTask { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public required virtual User User { get; set; }
}