using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class RoleBuilder
{
    public static void ConfigureRole(ModelBuilder builder)
    {
        builder.Entity<Role>()
           .HasOne(u => u.User)
           .WithMany(r => r.Roles)
           .HasForeignKey(u => u.UserId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}