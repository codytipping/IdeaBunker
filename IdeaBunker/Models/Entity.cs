using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Models;

public class Entity
{
    [Key]
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}