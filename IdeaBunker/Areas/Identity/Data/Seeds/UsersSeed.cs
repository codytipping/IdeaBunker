using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;

namespace IdeaBunker.Seeds;

public static class UsersSeed
{
    private const string FirstName = "Permissions";
    private const string LastName = "Master";
    private const string UserName = "Permissions Master";
    private const string Email = "permissionsmaster@email.com";
    private const string Password = "123Pa$$word!";

    private static string GetPassword() { return Password; }

    public static async Task SeedUserAsync(UserManager<User> userManager)
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
            await userManager.AddToRoleAsync(user, RolesSeed.GetName());            
        }
    }
}