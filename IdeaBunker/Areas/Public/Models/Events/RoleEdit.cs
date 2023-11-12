using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class RoleEdit : Event
{
    public required string RoleId { get; set; }
    public required string RoleName { get; set; }
}