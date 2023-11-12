using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class IdentityContext : IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<RoleEvent> RoleEvents { get; set; }
    public DbSet<UserEvent> UserEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
        builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
        builder.Entity<Role>(entity => { entity.ToTable(name: "Roles"); });
        builder.Entity<User>(entity => { entity.ToTable(name: "Users"); });

        builder.Entity<Role>()
            .HasOne(u => u.User)
            .WithMany(r => r.Roles)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
            .HasOne(u => u.Clearance)
            .WithMany(sc => sc.Users)
            .HasForeignKey(u => u.ClearanceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>()
            .HasOne(u => u.Rank)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RankId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}