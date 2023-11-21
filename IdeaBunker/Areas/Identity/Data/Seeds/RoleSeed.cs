using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Models;
using IdeaBunker.Permissions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdeaBunker.Seeds;

public static class RoleSeed
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

    private static async Task AddPermissionsAsync(this RoleManager<Role> manager, IList<string> permissions)
    {
        var role = await manager.FindByNameAsync(Name) ?? new();
        foreach (var permission in permissions)
        {
            await manager.AddClaimAsync(role, new Claim(ClaimType, permission));
        }
    }

    private static IList<string> GetPermissions(Type module)
    {
        if (module is not null && typeof(BasePermissions).IsAssignableFrom(module))
        {
            var instance = Activator.CreateInstance(module) as BasePermissions;
            if (instance is not null) { return instance.GetList(); }
        }
        return new List<string>();
    }

    private static async Task SeedClaimsAsync(this RoleManager<Role> manager)
    {       
        var modules = typeof(PermissionsMaster).GetNestedTypes();
        foreach (var module in modules)
        {
            var permissions = GetPermissions(module);
            await manager.AddPermissionsAsync(permissions);
        }
    }
}