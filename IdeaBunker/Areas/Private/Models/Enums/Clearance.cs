namespace IdeaBunker.Models;

public class Clearance : Enum
{
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Project>? Projects { get; set; }
}