using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Enums;

public class StatusProject : IdeaBunker.Models.Enum
{
    public virtual ICollection<Project>? Projects { get; set; }
}