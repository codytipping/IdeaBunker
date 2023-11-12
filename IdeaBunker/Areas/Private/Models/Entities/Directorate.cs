using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;
using static System.Collections.Specialized.BitVector32;

namespace IdeaBunker.Areas.Private.Models.Entities;

public class Directorate : Entity
{
    public virtual ICollection<Section>? Sections { get; set; }
    public ICollection<DirectorateProject>? DirectorateProjects { get; set; }
    public ICollection<DirectorateUser>? DirectorateUsers { get; set; }
}

public class DirectorateProject
{
    public required Guid ProjectId { get; set; }
    public required Project Project { get; set; }
    public required Guid DirectorateId { get; set; }
    public required Directorate Directorate { get; set; }
}

public class DirectorateUser
{
    public required string UserId { get; set; }
    public required User User { get; set; }
    public required Guid DirectorateId { get; set; }
    public required Directorate Directorate { get; set; }
}