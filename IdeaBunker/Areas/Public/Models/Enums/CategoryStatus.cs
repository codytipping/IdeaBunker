namespace IdeaBunker.Areas.Public.Models;

public class CategoryStatus : IdeaBunker.Models.Enum
{
    public virtual ICollection<Category>? Categories { get; set; }
}