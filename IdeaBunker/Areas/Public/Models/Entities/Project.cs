﻿using IdeaBunker.Areas.Identity.Data;
using IdeaBunker.Areas.Public.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Entities;

public class Project : Entity
{
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;

    [ForeignKey("Category")]
    public required Guid CategoryId { get; set; }
    public required virtual Category Category { get; set; }

    [ForeignKey("Clearance")]
    public required Guid ClearanceId { get; set; }
    public required virtual Clearance Clearance { get; set; }

    [ForeignKey("IdentityUser")]
    public required string UserId { get; set; }
    public required virtual IdeaBunkerUser IdentityUser { get; set; }

    [ForeignKey("Status")]
    public required Guid StatusId { get; set; }
    public required virtual StatusProject Status { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<DirectorateProject>? DirectorateProjects { get; set; }
    public virtual ICollection<DivisionProject>? DivisionProjects { get; set; }
    public virtual ICollection<Document>? Documents { get; set; }
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
    public virtual ICollection<SectionProject>? SectionProjects { get; set; }
    public virtual ICollection<TeamProject>? TeamProjects { get; set; }
}