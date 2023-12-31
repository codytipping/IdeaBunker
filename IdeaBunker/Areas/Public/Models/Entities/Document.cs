﻿using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Areas.Public.Models;

public class Document : Entity
{
    public required byte[] Data { get; set; }
    public required string Path { get; set; }
    public required string Mime { get; set; }

    [ForeignKey("Project")]
    public required string ProjectId { get; set; }
    public virtual Project? Project { get; set; }

    [ForeignKey("User")]
    public required string UserId { get; set; }
    public virtual User? User { get; set; }
}