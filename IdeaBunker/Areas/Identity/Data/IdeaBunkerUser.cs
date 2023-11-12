using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Areas.Public.Models.Enums;

namespace IdeaBunker.Areas.Identity.Data;
public class IdeaBunkerUser : IdentityUser
{
    [PersonalData]
    [StringLength(100)]
    public required string FirstName { get; set; }

    [PersonalData]
    [StringLength(100)]
    public required string LastName { get; set; }
    
    [ForeignKey("MilitaryRank")]
    public Guid RankId { get; set; }
    public required virtual Rank Rank { get; set; }

    [ForeignKey("Clearance")]
    public Guid ClearanceId { get; set; }
    public required virtual Clearance Clearance { get; set; }

    public virtual ICollection<Category>? Categories { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<DirectorateUser>? DirectorateUsers { get; set; }
    public virtual ICollection<Document>? Documents { get; set; }
    public virtual ICollection<DivisionUser>? DivisionUsers { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
    public virtual ICollection<IdeaBunkerRole>? Roles { get; set; }
    public virtual ICollection<SectionUser>? SectionUsers { get; set; }
    public virtual ICollection<TeamUser>? TeamUsers { get; set; }
}