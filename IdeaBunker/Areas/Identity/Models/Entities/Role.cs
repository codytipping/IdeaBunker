using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Identity.Models.Entities;
public class Role : IdentityRole
{
    [MinLength(50), StringLength(1000)]
    public required string Description { get; set; }

    [ForeignKey("IdeaBunkerUser")]
    public required string UserId { get; set; }
    public required virtual User IdeaBunkerUser { get; set; }
}