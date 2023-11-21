using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.ViewModels;

public class UserViewModel
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RankName { get; set; } = string.Empty;
    public string ClearanceName { get; set; } = string.Empty;
}