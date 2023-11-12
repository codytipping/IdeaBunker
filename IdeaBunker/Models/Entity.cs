using IdeaBunker.Areas.Identity.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Entity
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(1000)]
    public required string Description { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public required virtual User User { get; set; }
}