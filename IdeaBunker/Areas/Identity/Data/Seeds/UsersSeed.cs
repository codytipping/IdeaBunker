using IdeaBunker.Models;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;

namespace IdeaBunker.Seeds;

public static class UsersSeed
{
    private const string FirstName = "Permissions";
    private const string LastName = "Master";
    private const string UserName = "Permissions Master";
    private const string Email = "permissionsmaster@email.com";
    private const string Password = "123Pa$$word!";

    private static string GetPassword() { return Password; }

    public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        if (!userManager.Users.Any()) 
        {
            User user = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            await userManager.CreateAsync(user, GetPassword());         
            await userManager.AddToRoleAsync(user, "SuperAdmin");
            await roleManager.SeedClaimsAsync();
        }
    }

    private static async Task SeedClaimsAsync(this RoleManager<Role> roleManager)
    {
        var role = await roleManager.FindByNameAsync("SuperAdmin") ?? new();
        var modules = typeof(PermissionsMaster).GetNestedTypes();
        foreach (var module in modules)
        {
            var list = module.GetMethod("GetList");
            if (list is IList<string> permissions)
            {
                await roleManager.AddPermissionClaimsAsync(role, permissions);
            }
        }       
    }

    private static async Task AddPermissionClaimsAsync(this RoleManager<Role> roleManager, Role role, IList<string> permissions)
    {
        var claims = await roleManager.GetClaimsAsync(role);
        foreach (var permission in permissions)
        {
            if (!claims.Any(c => c.Type == "Permission" && c.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}