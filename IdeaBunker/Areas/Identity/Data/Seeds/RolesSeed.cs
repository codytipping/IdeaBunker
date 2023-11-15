using IdeaBunker.Models;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdeaBunker.Seeds;

public static class RolesSeed
{
    private const string Name = "PermissionsMaster";
    private const string ClaimType = "Permission";

    public static string GetName() { return Name; }

    public static async Task SeedRoleAsync(RoleManager<Role> roleManager)
    {       
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new Role { Name = Name });
            await roleManager.SeedClaimsAsync();
        }
    }

    private static async Task AddPermissionsAsync(this RoleManager<Role> roleManager, Role role, IList<string> permissions)
    {       
        foreach (var permission in permissions)
        {
            await roleManager.AddClaimAsync(role, new Claim(ClaimType, permission));
        }
    }

    private static async Task SeedClaimsAsync(this RoleManager<Role> roleManager)
    {
        var role = await roleManager.FindByNameAsync(Name) ?? new();
        var modules = typeof(PermissionsMaster).GetNestedTypes();
        foreach (var module in modules)
        {
            var list = module.GetMethod("GetList");
            if (list is IList<string> permissions)
            {
                await roleManager.AddPermissionsAsync(role, permissions);
            }
        }
    }
}