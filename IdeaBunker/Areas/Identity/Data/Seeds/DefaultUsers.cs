using System.Security.Claims;
using IdeaBunker.Data;
using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Seeds;

public static class DefaultUsers
{
    public static async Task SeedBasicUserAsync
        (UserManager<User> userManager, RoleManager<Role> roleManager, Context context)
    {
        var defaultMilitaryRank = context.Ranks.FirstOrDefault();
        var defaultSecurityClearance = context.Clearances.FirstOrDefault();
        var defaultUser = new User
        {
            FirstName = "Basic",
            LastName = "User",
            RankId = defaultMilitaryRank?.Id ?? string.Empty,
            ClearanceId = defaultSecurityClearance?.Id ?? string.Empty,
            UserName = "basicuser@gmail.com",
            Email = "basicuser@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, "Basic");
            }
        }
        var roleExists = await roleManager.RoleExistsAsync("Basic");
        var userRole = await roleManager.FindByNameAsync("Basic");
        if (roleExists && userRole?.UserId == null)
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            userRole.UserId = user.Id;
            await roleManager.UpdateAsync(userRole);
        }
    }

    public static async Task SeedSuperAdminAsync
        (UserManager<User> userManager, RoleManager<Role> roleManager, Context context)
    {
        var defaultMilitaryRank = context.Ranks.FirstOrDefault();
        var defaultSecurityClearance = context.Clearances.FirstOrDefault();
        var defaultUser = new User
        {
            FirstName = "Super",
            LastName = "Admin",
            RankId = defaultMilitaryRank?.Id ?? string.Empty,
            ClearanceId = defaultSecurityClearance?.Id ?? string.Empty,
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, "SuperAdmin");
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
        var roleExists = await roleManager.RoleExistsAsync("SuperAdmin");
        var userRole = await roleManager.FindByNameAsync("SuperAdmin");
        if (roleExists && userRole.UserId == null)
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            userRole.UserId = user.Id;
            await roleManager.UpdateAsync(userRole);
        }
    }

    private async static Task SeedClaimsForSuperAdmin(this RoleManager<Role> roleManager)
    {
        var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
        await roleManager.AddPermissionClaim(adminRole, "Categories");
        await roleManager.AddPermissionClaim(adminRole, "Comments");
        await roleManager.AddPermissionClaim(adminRole, "Documents");
        await roleManager.AddPermissionClaim(adminRole, "PermissionSet");
        await roleManager.AddPermissionClaim(adminRole, "Projects");
        await roleManager.AddPermissionClaim(adminRole, "Roles");
    }
    public static async Task AddPermissionClaim
        (this RoleManager<Role> roleManager, Role role, string module)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        var allPermissions = PermissionSeeds.GeneratePermissionsForModule(module);
        foreach (var permission in allPermissions)
        {
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
