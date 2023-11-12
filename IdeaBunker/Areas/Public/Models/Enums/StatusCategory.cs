using IdeaBunker.Areas.Public.Models.Entities;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.Areas.Public.Models.Enums;

public class StatusCategory : IdeaBunker.Models.Enum
{
    public virtual ICollection<Category>? Categories { get; set; }
}