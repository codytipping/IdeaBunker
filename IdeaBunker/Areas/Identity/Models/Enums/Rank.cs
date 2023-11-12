namespace IdeaBunker.Models;

public class Rank : Enum
{
    public virtual ICollection<User>? Users { get; set; }
}