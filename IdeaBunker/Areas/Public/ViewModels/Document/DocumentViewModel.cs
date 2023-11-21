using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class DocumentViewModel : ViewModel
{
    public string? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public IFormFile? UploadedDocument { get; set; }
    public string? Path { get; set; }
    public string? Mime { get; set; }
}