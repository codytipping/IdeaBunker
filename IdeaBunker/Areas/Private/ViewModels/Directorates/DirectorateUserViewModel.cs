namespace IdeaBunker.ViewModels;

public class DirectorateUserViewModel : ViewModel
{
    public IList<UserSelectionViewModel>? UserDirectorate { get; set; }
    public IList<UserSelectionViewModel>? UserSearch { get; set; }
    public IList<UserSelectionViewModel>? UserSelection { get; set; }
}