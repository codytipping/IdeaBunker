using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;
public class Role : IdentityRole
{
    [MinLength(50), StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [ForeignKey("IdeaBunkerUser")]
    public string? UserId { get; set; }
    public virtual User? User { get; set; }
  
    /*
    public virtual ICollection<DirectorateRole>? DirectorateRoles { get; set; }
    public virtual ICollection<DivisionRole>? DivisionRoles { get; set; }
    public virtual ICollection<SectionRole>? SectionRoles { get; set; }
    public virtual ICollection<TeamRole>? TeamRoles { get; set; }*/
}