using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Private.Models.Enums;

public class Clearance : IdeaBunker.Models.Enum
{
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
}