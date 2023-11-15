using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class DirectorateBuilder
{
    public static void ConfigureDirectorate(ModelBuilder builder)
    {
        builder.Entity<DirectorateProject>().HasKey(dp => new { dp.ProjectId, dp.DirectorateId });
        builder.Entity<DirectorateRole>().HasKey(dr => new { dr.RoleId, dr.DirectorateId });
        builder.Entity<DirectorateUser>().HasKey(du => new { du.UserId, du.DirectorateId });
        builder.Entity<Directorate>()
           .HasMany(d => d.Sections)
           .WithOne(s => s.Directorate)
           .HasForeignKey(s => s.DirectorateId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}