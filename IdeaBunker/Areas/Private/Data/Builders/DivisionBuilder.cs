using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class DivisionBuilder
{
    public static void ConfigureDivision(ModelBuilder builder)
    {
        builder.Entity<DivisionProject>().HasKey(dp => new { dp.ProjectId, dp.DivisionId });
        builder.Entity<DivisionRole>().HasKey(dr => new { dr.RoleId, dr.DivisionId });
        builder.Entity<DivisionUser>().HasKey(du => new { du.UserId, du.DivisionId });

        builder.Entity<Division>()
            .HasMany(d => d.Teams)
            .WithOne(t => t.Division)
            .HasForeignKey(t => t.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}