namespace IdeaBunker.ViewModels;

public class SectionRegistryViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? SectionProjects { get; set; }
    public IList<RoleSelectionViewModel>? SectionRoles { get; set; }
    public IList<UserSelectionViewModel>? SectionUsers { get; set; }
}