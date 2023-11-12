using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Enum
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(1000)]
    public required string Description { get; set; }
}