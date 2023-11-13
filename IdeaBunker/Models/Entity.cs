using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Entity
{
    [Key]
    public string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}