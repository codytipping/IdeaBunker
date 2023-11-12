using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Category : Entity
{   
    [ForeignKey("Status")]
    public required string StatusId { get; set; }
    public required virtual StatusCategory Status { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public required virtual User User { get; set; }

    public ICollection<Project>? Projects { get; set; }
}