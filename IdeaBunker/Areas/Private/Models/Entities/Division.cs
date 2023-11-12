using System.ComponentModel.DataAnnotations.Schema;
using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class Division : Entity
{
    [ForeignKey("Section")]
    public required Guid SectionId { get; set; }
    public required virtual Section Section { get; set; }

    public virtual ICollection<Team>? Teams { get; set; }
    public virtual ICollection<DivisionProject>? DivisionProjects { get; set; }
    public virtual ICollection<DivisionUser>? DivisionUsers { get; set; }
}

public class DivisionProject
{
    public required Guid ProjectId { get; set; }
    public required Project Project { get; set; }
    public required Guid DivisionId { get; set; }
    public required Division Division { get; set; }
}

public class DivisionUser
{
    public string? UserId { get; set; }
    public required User User { get; set; }
    public required Guid DivisionId { get; set; }
    public required Division Division { get; set; }
}