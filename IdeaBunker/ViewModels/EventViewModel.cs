namespace IdeaBunker.ViewModels;

public class EventViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string EventDescription { get; set; } = string.Empty;
    public bool ShowModal { get; set; }
}