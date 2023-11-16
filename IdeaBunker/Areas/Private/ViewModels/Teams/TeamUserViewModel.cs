namespace IdeaBunker.ViewModels;

public class TeamUserViewModel : ViewModel
{
    public IList<UserSelectionViewModel>? UserTeam { get; set; }
    public IList<UserSelectionViewModel>? UserSearch { get; set; }
    public IList<UserSelectionViewModel>? UserSelection { get; set; }
}