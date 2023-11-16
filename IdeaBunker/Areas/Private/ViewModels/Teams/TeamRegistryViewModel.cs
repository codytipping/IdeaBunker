namespace IdeaBunker.ViewModels;

public class TeamRegistryViewModel : ViewModel
{
    public IList<ProjectSelectionViewModel>? TeamProjects { get; set; }
    public IList<RoleSelectionViewModel>? TeamRoles { get; set; }
    public IList<UserSelectionViewModel>? TeamUsers { get; set; }
}