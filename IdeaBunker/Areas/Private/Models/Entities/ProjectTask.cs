using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Private.Models.Enums;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class ProjectTask : Entity
{
    public int? UpvoteCount { get; set; }
    public int? DownvoteCount { get; set; }

    [ForeignKey("IdentityUser")]
    public required string UserId { get; set; }
    public required virtual User IdentityUser { get; set; }

    [ForeignKey("Status")]
    public required Guid StatusId { get; set; }
    public required virtual StatusProjectTask Status { get; set; }

    [ForeignKey("Project")]
    public required Guid ProjectId { get; set; }
    public required virtual Project Project { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}