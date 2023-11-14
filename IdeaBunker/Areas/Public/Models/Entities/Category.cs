using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Category : Entity
{   
    [ForeignKey("Status")]
    public required string StatusId { get; set; }
    public virtual StatusCategory? Status { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; } = string.Empty;
    public virtual User? User { get; set; }

    public ICollection<Project>? Projects { get; set; }
}