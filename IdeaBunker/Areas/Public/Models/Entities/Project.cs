using IdeaBunker.Areas.Private.Models;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Public.Models;

public class Project : Entity
{
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;

    [ForeignKey("Category")]
    public string CategoryId { get; set; } = string.Empty;
    public virtual Category? Category { get; set; }

    [ForeignKey("Clearance")]
    public string ClearanceId { get; set; } = string.Empty;
    public virtual Clearance? Clearance { get; set; }

    [ForeignKey("Status")]
    public string StatusId { get; set; } = string.Empty;
    public virtual ProjectStatus? Status { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; } = string.Empty;
    public virtual User? User { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    /*
    public virtual ICollection<DirectorateProject>? DirectorateProjects { get; set; }
    public virtual ICollection<DivisionProject>? DivisionProjects { get; set; } */
    public virtual ICollection<Document>? Documents { get; set; }
    /*
    public virtual ICollection<ProjectTask>? ProjectTasks { get; set; }
    public virtual ICollection<SectionProject>? SectionProjects { get; set; }
    public virtual ICollection<TeamProject>? TeamProjects { get; set; }*/
}