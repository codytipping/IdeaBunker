using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class SectionBuilder
{
    public static void ConfigureSection(ModelBuilder builder)
    {
        builder.Entity<SectionProject>().HasKey(sp => new { sp.ProjectId, sp.SectionId });
        builder.Entity<SectionRole>().HasKey(sr => new { sr.RoleId, sr.SectionId });
        builder.Entity<SectionUser>().HasKey(su => new { su.UserId, su.SectionId });

        builder.Entity<Section>()
            .HasMany(s => s.Divisions)
            .WithOne(d => d.Section)
            .HasForeignKey(d => d.SectionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SectionProject>()
            .HasOne(sp => sp.Section)
            .WithMany(p => p.SectionProjects)
            .HasForeignKey(sp => sp.SectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SectionProject>()
            .HasOne(sp => sp.Project)
            .WithMany(u => u.SectionProjects)
            .HasForeignKey(sp => sp.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SectionRole>()
            .HasOne(sr => sr.Section)
            .WithMany(s => s.SectionRoles)
            .HasForeignKey(sr => sr.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SectionRole>()
            .HasOne(sr => sr.Role)
            .WithMany(u => u.SectionRoles)
            .HasForeignKey(sr => sr.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SectionUser>()
            .HasOne(su => su.Section)
            .WithMany(s => s.SectionUsers)
            .HasForeignKey(su => su.SectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SectionUser>()
            .HasOne(su => su.User)
            .WithMany(u => u.SectionUsers)
            .HasForeignKey(su => su.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}