using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Seeds;

public class DefaultRoles
{
    public static async Task SeedAsync(RoleManager<Role> roleManager)
    {       
        await roleManager.CreateAsync(new Role { Name = "SuperAdmin" });
        await roleManager.CreateAsync(new Role { Name = "Basic" });
    }
}