namespace IdeaBunker.Models;

public class Directorate : Entity
{
    public virtual ICollection<Section>? Sections { get; set; }
    public ICollection<DirectorateProject>? DirectorateProjects { get; set; }
    public virtual ICollection<DirectorateRole>? DirectorateRoles { get; set; }
    public ICollection<DirectorateUser>? DirectorateUsers { get; set; }
}

public class DirectorateProject
{
    public required string ProjectId { get; set; }
    public required Project Project { get; set; }
    public required string DirectorateId { get; set; }
    public required Directorate Directorate { get; set; }
}

public class DirectorateRole
{
    public required string RoleId { get; set; }
    public required Role Role { get; set; }
    public required string DirectorateId { get; set; }
    public required Directorate Directorate { get; set; }
}

public class DirectorateUser
{
    public required string UserId { get; set; }
    public required User User { get; set; }
    public required string DirectorateId { get; set; }
    public required Directorate Directorate { get; set; }
}