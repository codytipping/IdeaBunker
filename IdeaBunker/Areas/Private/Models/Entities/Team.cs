using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class Team : Entity
{
    [ForeignKey("Division")]
    public required string DivisionId { get; set; }
    public required virtual Division Division { get; set; }

    public virtual ICollection<TeamProject>? TeamProjects { get; set; }
    public virtual ICollection<TeamRole>? TeamRoles { get; set; }
    public virtual ICollection<TeamUser>? TeamUsers { get; set; }
}

public class TeamProject
{
    public required string ProjectId { get; set; }
    public required Project Project { get; set; }
    public required string TeamId { get; set; }
    public required Team Team { get; set; }
}

public class TeamRole
{
    public required string RoleId { get; set; }
    public required Role Role { get; set; }
    public required string TeamId { get; set; }
    public required Team Team { get; set; }
}

public class TeamUser
{
    public required string UserId { get; set; }
    public required User User { get; set; }
    public required string TeamId { get; set; }
    public required Team Team { get; set; }
}