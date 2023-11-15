using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class IdentityBuilder
{
    public static void ConfigureIdentity(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RolesClaim"); });
        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UsersClaim"); });
        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UsersLogin"); });
        builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UsersRole"); });
        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UsersToken"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles"); });
        builder.Entity<User>(entity => { entity.ToTable(name: "Users"); });
    }
}