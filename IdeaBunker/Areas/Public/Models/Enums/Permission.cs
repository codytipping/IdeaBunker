using System.ComponentModel.DataAnnotations;
using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Enums;

public class Permission : IdeaBunker.Models.Enum
{
    [StringLength(100)]
    public required string Module { get; set; }

    [StringLength(100)]
    public required string Action { get; set; }
}
