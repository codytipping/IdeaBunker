namespace IdeaBunker.ViewModels;

public class SectionUserViewModel : ViewModel
{
    public IList<UserSelectionViewModel>? UserSection { get; set; }
    public IList<UserSelectionViewModel>? UserSearch { get; set; }
    public IList<UserSelectionViewModel>? UserSelection { get; set; }
}