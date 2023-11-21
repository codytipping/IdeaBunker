using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class ProjectVoteViewModel : ViewModel
{
    public string VoteType { get; set; } = string.Empty;
    public int UpvoteCount { get; set; } = 0;
    public int DownvoteCount { get; set; } = 0;
}