namespace IdeaBunker.Models;

public class StatusProject : Enum
{
    public virtual ICollection<Project>? Projects { get; set; }
}