using IdeaBunker.Areas.Private.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IdeaBunker.Models;
using IdeaBunker.Areas.Identity.Models.Entities;

namespace IdeaBunker.Areas.Public.Models.Entities;

public class Comment : Entity
{   
    [ForeignKey("Project")]
    public required Guid ProjectId { get; set; }
    public required virtual Project Project { get; set; }

    [ForeignKey("ProjectTask")]
    public required Guid ProjectTaskId { get; set; }
    public required virtual ProjectTask ProjectTask { get; set; }
}