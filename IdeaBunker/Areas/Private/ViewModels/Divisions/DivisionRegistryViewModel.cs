namespace IdeaBunker.ViewModels;

public class DivisionRegistryViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? DivisionProjects { get; set; }
    public IList<RoleSelectionViewModel>? DivisionRoles { get; set; }
    public IList<UserSelectionViewModel>? DivisionUsers { get; set; }
}