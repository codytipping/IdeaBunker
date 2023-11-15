using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Seeds;

public static class DefaultUsers
{
    public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager, Context context)
    {
        if (!userManager.Users.Any()) 
        {
            var rank = context.Ranks.FirstOrDefault();
            var clearance = context.Clearances.FirstOrDefault();
            var user = new User
            {
                FirstName = "Super",
                LastName = "Admin",
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                RankId = rank?.Id ?? string.Empty,
                ClearanceId = clearance?.Id ?? string.Empty,
            };
            await userManager.CreateAsync(user, "123Pa$$word!");         
            await userManager.AddToRoleAsync(user, "SuperAdmin");
            await roleManager.SeedClaimsAsync();
        }
    }

    private static async Task SeedClaimsAsync(this RoleManager<Role> roleManager)
    {
        var role = await roleManager.FindByNameAsync("SuperAdmin") ?? new();
        // Create a for-loop to address each permission module:
        await roleManager.AddPermissionClaim(role, "Categories");
        await roleManager.AddPermissionClaim(role, "Comments");
        await roleManager.AddPermissionClaim(role, "Documents");
        await roleManager.AddPermissionClaim(role, "PermissionSet");
        await roleManager.AddPermissionClaim(role, "Projects");
        await roleManager.AddPermissionClaim(role, "Roles");
    }
}