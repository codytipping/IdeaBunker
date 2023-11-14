using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Enum
{
    [Key]
    public string Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;

    public Enum()
    {
        Id = Guid.NewGuid().ToString();
    }
}