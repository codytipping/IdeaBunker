using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Identity.Data;
public class IdeaBunkerRole : IdentityRole
{
    [MinLength(50), StringLength(1000)]
    public required string Description { get; set; }

    [ForeignKey("IdeaBunkerUser")]
    public required string UserId { get; set; }
    public required virtual IdeaBunkerUser IdeaBunkerUser { get; set; }   
}