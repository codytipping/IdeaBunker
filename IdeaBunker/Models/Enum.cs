using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Enum
{
    [Key]
    public string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public Enum()
    {
        Id = Guid.NewGuid().ToString();
    }
}