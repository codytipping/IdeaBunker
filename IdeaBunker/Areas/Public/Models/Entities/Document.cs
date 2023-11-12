﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IdeaBunker.Models;
using IdeaBunker.Areas.Identity.Models.Entities;

namespace IdeaBunker.Areas.Public.Models.Entities;

public class Document : Entity
{
    public required byte[] Data { get; set; }
    public required string Path { get; set; }
    public required string Mime { get; set; }

    [ForeignKey("IdentityUser")]
    public required string UserId { get; set; }
    public required virtual User IdentityUser { get; set; }

    [ForeignKey("Project")]
    public required Guid ProjectId { get; set; }
    public required virtual Project Project { get; set; }
}
