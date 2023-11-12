using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class RoleAssign : Event
{
    public required string ClaimantId { get; set; }
    public required string ClaimantNameAndRank { get; set; }
    public required string RoleId { get; set; }
    public required string RoleName { get; set; }
}