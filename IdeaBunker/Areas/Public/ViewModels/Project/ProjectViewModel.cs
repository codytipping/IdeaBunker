using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class ProjectViewModel : ViewModel
{
    public string CategoryId { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string ClearanceId { get; set; } = string.Empty;
    public string StatusId { get; set; } = string.Empty;
    public string StatusName { get; set; } = string.Empty;
    public bool? VoteType { get; set; } = null;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;    
}