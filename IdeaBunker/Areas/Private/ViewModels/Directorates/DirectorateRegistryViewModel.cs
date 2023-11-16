namespace IdeaBunker.ViewModels;

public class DirectorateRegistryViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? DirectorateProjects { get; set; }
    public IList<RoleSelectionViewModel>? DirectorateRoles { get; set; }
    public IList<UserSelectionViewModel>? DirectorateUsers { get; set; }
}