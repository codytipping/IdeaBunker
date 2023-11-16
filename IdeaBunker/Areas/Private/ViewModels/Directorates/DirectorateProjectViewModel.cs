namespace IdeaBunker.ViewModels;

public class DirectorateProjectViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? ProjectDirectorate { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSearch { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSelection { get; set; }
}