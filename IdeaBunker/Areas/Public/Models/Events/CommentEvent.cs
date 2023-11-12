using System.ComponentModel.DataAnnotations;
using IdeaBunker.Models;

namespace IdeaBunker.Areas.Public.Models.Events;

public class CommentEvent : Event
{
    public required string CommentId { get; set; }
    public required string ProjectId { get; set; }
    public required string ProjectName { get; set; }
}