using IdeaBunker.Models;

namespace IdeaBunker.Areas.Identity.Models.Events;

public class RoleEvent : Event
{
    public required string ClaimantId { get; set; }
    public required string ClaimantNameAndRank { get; set; }
    public required string RoleId { get; set; }
    public required string RoleName { get; set; }
}