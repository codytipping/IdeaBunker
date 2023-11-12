﻿using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Public.Models.Enums;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Public.Models.Entities;

public class Category : Entity
{   
    [ForeignKey("Status")]
    public required Guid StatusId { get; set; }
    public required virtual StatusCategory Status { get; set; }

    public ICollection<Project>? Projects { get; set; }
}