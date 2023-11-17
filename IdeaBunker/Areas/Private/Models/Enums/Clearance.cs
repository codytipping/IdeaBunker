using IdeaBunker.Areas.Public.Models;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models;

public class Clearance : IdeaBunker.Models.Enum
{
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
}