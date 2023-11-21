using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Public.Models;

public class Comment : Entity
{
    [ForeignKey("Project")]
    public required string ProjectId { get; set; }
    public virtual Project? Project { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public virtual User? User { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;
}