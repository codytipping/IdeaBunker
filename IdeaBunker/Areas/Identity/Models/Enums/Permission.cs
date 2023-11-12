using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Areas.Identity.Models.Enums;

public class Permission : IdeaBunker.Models.Enum
{
    [StringLength(100)]
    public required string Module { get; set; }

    [StringLength(100)]
    public required string Action { get; set; }
}