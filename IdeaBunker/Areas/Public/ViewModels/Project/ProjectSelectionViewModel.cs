namespace IdeaBunker.Areas.Public.ViewModels;

public class ProjectSelectionViewModel
{
    public string ProjectId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UserNameAndRank { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;
    public bool Selected { get; set; }
}