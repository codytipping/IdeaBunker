namespace IdeaBunker.ViewModels;

public class TeamProjectViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? ProjectTeam { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSearch { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSelection { get; set; }
}