namespace IdeaBunker.Areas.Identity.Models;


public class Rank : IdeaBunker.Models.Enum
{
    public virtual ICollection<User>? Users { get; set; }
}