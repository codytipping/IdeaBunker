using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class Section : Entity
{
    [ForeignKey("Directorate")]
    public required string DirectorateId { get; set; }
    public required virtual Directorate Directorate { get; set; }

    public virtual ICollection<Division>? Divisions { get; set; }
    public virtual ICollection<SectionProject>? SectionProjects { get; set; }
    public virtual ICollection<SectionRole>? SectionRoles { get; set; }
    public virtual ICollection<SectionUser>? SectionUsers { get; set; }
}

public class SectionProject
{
    public required string ProjectId { get; set; }
    public required Project Project { get; set; }
    public required string SectionId { get; set; }
    public required Section Section { get; set; }
}

public class SectionRole
{
    public required string RoleId { get; set; }
    public required Role Role { get; set; }
    public required string SectionId { get; set; }
    public required Section Section { get; set; }
}

public class SectionUser
{
    public required string UserId { get; set; }
    public required User User { get; set; }
    public required string SectionId { get; set; }
    public required Section Section { get; set; }
}