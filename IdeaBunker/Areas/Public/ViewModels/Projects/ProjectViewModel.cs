namespace IdeaBunker.ViewModels;

public class ProjectViewModel : ViewModel
{
    public string? CategoryId { get; set; }
    public string? ClearanceId { get; set; }
    public string? StatusId { get; set; }
    public int? UpvoteCount { get; set; }
    public int? DownvoteCount { get; set; }
}