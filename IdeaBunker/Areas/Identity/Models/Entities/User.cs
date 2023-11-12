﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Areas.Identity.Models.Enums;
using IdeaBunker.Areas.Private.Models.Enums;
using IdeaBunker.Areas.Private.Models.Entities;

namespace IdeaBunker.Areas.Identity.Models.Entities;
public class User : IdentityUser
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
    public virtual ICollection<Role>? Roles { get; set; }
    public virtual ICollection<SectionUser>? SectionUsers { get; set; }
    public virtual ICollection<TeamUser>? TeamUsers { get; set; }
}