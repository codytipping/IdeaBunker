﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using IdeaBunker.Areas.Private.Models.Entities;

namespace IdeaBunker.Areas.Identity.Models.Entities;
public class Role : IdentityRole
{
    [MinLength(50), StringLength(1000)]
    public required string Description { get; set; }

    [ForeignKey("IdeaBunkerUser")]
    public required string UserId { get; set; }
    public required virtual User User { get; set; }

    public virtual ICollection<DirectorateRole>? DirectorateRoles { get; set; }
    public virtual ICollection<DivisionRole>? DivisionRoles { get; set; }
    public virtual ICollection<SectionRole>? SectionRoles { get; set; }
    public virtual ICollection<TeamRole>? TeamRoles { get; set; }
}