using IdeaBunker.Areas.Identity.Data;
using IdeaBunker.Areas.Public.Models.Enums;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Public.Models.Entities;

public class Category : Entity
{
    [ForeignKey("IdentityUser")]
    public required string UserId { get; set; }
    public required virtual IdeaBunkerUser IdentityUser { get; set; }
    
    [ForeignKey("Status")]
    public required Guid StatusId { get; set; }
    public required virtual StatusCategory Status { get; set; }

    public ICollection<Project>? Projects { get; set; }
}