﻿using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaBunker.Models;

public class Category : Entity
{   
    [ForeignKey("Status")]
    public string? StatusId { get; set; }
    public virtual CategoryStatus? Status { get; set; }

    [ForeignKey("User")]
    public string? UserId { get; set; }
    public virtual User? User { get; set; }

    public ICollection<Project>? Projects { get; set; }
}