using System.ComponentModel.DataAnnotations.Schema;
using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class Division : Entity
{
    [ForeignKey("Section")]
    public required string SectionId { get; set; }
    public required virtual Section Section { get; set; }

    public virtual ICollection<Team>? Teams { get; set; }
    public virtual ICollection<DivisionProject>? DivisionProjects { get; set; }
    public virtual ICollection<DivisionRole>? DivisionRoles { get; set; }
    public virtual ICollection<DivisionUser>? DivisionUsers { get; set; }
}

public class DivisionProject
{
    public required string ProjectId { get; set; }
    public required Project Project { get; set; }
    public required string DivisionId { get; set; }
    public required Division Division { get; set; }
}

public class DivisionRole
{
    public required string RoleId { get; set; }
    public required Role Role { get; set; }
    public required string DivisionId { get; set; }
    public required Division Division { get; set; }
}

public class DivisionUser
{
    public required string UserId { get; set; }
    public required User User { get; set; }
    public required string DivisionId { get; set; }
    public required Division Division { get; set; }
}