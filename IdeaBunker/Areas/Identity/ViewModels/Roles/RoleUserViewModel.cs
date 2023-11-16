using System.ComponentModel.DataAnnotations;

namespace IdeaBunker.ViewModels;

public class RoleUserViewModel
{
    public string? RoleId { get; set; }
    public string? RoleName { get; set; }
    public bool? Selected { get; set; }
}

public class ManageUserRolesViewModel
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? EventDescription { get; set; }

    public IList<RoleUserViewModel>? UserRoles { get; set; }
}