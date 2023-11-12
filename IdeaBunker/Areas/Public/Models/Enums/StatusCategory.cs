namespace IdeaBunker.Models;

public class StatusCategory : Enum
{
    public virtual ICollection<Category>? Categories { get; set; }
}