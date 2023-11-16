namespace IdeaBunker.ViewModels;

public class SectionProjectViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? ProjectSection { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSearch { get; set; }
    public IList<ProjectSelectionViewModel>? ProjectSelection { get; set; }
}