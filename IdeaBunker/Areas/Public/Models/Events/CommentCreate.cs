using System.ComponentModel.DataAnnotations;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class CommentCreate : Event
{
    public required Guid CommentId { get; set; }
    public required Guid ProjectId { get; set; }
    public required string ProjectName { get; set; }
}