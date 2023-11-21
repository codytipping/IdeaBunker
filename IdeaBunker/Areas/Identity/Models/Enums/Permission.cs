namespace IdeaBunker.Areas.Identity.Models;

public class Permission : IdeaBunker.Models.Enum
{
    public required string Module { get; set; }
    public required string Action { get; set; }
}