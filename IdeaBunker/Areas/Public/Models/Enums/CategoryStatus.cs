namespace IdeaBunker.Models;

public class CategoryStatus : Enum
{
    public virtual ICollection<Category>? Categories { get; set; }
}