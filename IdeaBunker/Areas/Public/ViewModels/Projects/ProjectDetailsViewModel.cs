namespace IdeaBunker.ViewModels;

public class ProjectDetailsViewModel : ViewModel
{
    public string UserNameAndRank { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
    public string ClearanceDescription { get; set; } = string.Empty;
    public string StatusDescription { get; set; } = string.Empty;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;
}