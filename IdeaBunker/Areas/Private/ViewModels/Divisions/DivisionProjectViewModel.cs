namespace IdeaBunker.ViewModels;

public class DivisionProjectViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? ProjectDivision { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSearch { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSelection { get; set; }
}