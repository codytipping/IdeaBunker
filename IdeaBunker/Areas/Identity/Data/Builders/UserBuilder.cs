using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class UserBuilder
{
    public static void ConfigureUser(ModelBuilder builder)
    {
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