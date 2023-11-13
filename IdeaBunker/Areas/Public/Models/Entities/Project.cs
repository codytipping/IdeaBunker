﻿using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Project : Entity
{
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;

    [ForeignKey("Category")]
    public required string CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    [ForeignKey("Clearance")]
    public required string ClearanceId { get; set; }
    public virtual Clearance? Clearance { get; set; }

    [ForeignKey("Status")]
    public required string StatusId { get; set; }
    public virtual StatusProject? Status { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public virtual User? User { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<DirectorateProject>? DirectorateProjects { get; set; }
    public virtual ICollection<DivisionProject>? DivisionProjects { get; set; }
    public virtual ICollection<Document>? Documents { get; set; }
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
    public virtual ICollection<SectionProject>? SectionProjects { get; set; }
    public virtual ICollection<TeamProject>? TeamProjects { get; set; }
}