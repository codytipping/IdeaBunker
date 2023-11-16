namespace IdeaBunker.ViewModels;

public class DivisionUserViewModel : ViewModel
{
    public IList<UserSelectionViewModel>? UserDivision { get; set; }
    public IList<UserSelectionViewModel>? UserSearch { get; set; }
    public IList<UserSelectionViewModel>? UserSelection { get; set; }
}