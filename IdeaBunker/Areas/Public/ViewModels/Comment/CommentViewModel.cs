using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels.Comments;

public class CommentViewModel : ViewModel
{
    public string? ProjectId { get; set; }
    public string? ProjectName { get; set; }
}