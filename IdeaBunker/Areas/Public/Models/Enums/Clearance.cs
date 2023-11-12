using IdeaBunker.Areas.Identity.Data;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Enums;

public class Clearance : IdeaBunker.Models.Enum
{
    public virtual ICollection<IdeaBunkerUser>? IdentityUsers { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
}