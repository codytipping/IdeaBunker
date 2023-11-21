using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class ProjectDetailsViewModel : ViewModel
{
    public string CategoryDescription { get; set; } = string.Empty;
    public string StatusDescription { get; set; } = string.Empty;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;
    public CommentViewModel? Comment { get; set; }
    public IList<CommentViewModel>? Comments { get; set; }
    public DocumentViewModel? Document { get; set; }
    public IList<DocumentViewModel>? Documents { get; set; }
}