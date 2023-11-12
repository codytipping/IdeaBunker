using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Enum
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(1000)]
    public required string Description { get; set; }
}