using IdeaBunker.Areas.Identity.Models.Entities;

namespace IdeaBunker.Areas.Identity.Models.Enums;

public class Rank : IdeaBunker.Models.Enum
{
    public virtual ICollection<User>? Users { get; set; }
}