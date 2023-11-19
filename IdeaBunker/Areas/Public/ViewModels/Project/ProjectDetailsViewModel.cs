using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class ProjectDetailsViewModel : ViewModel
{
    public string CategoryDescription { get; set; } = string.Empty;
    public string StatusDescription { get; set; } = string.Empty;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;
}