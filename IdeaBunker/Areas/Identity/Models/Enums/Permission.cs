namespace IdeaBunker.Models;

public class Permission : Enum
{
    public required string Module { get; set; }
    public required string Action { get; set; }
}