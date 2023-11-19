using IdeaBunker.Areas.Public.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Data;

public class ProjectBuilder
{
    public static void ConfigureProject(ModelBuilder builder)
    {
        builder.Entity<Project>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasOne(p => p.User)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        /*builder.Entity<Project>()
            .HasMany(p => p.ProjectTasks)
            .WithOne(pt => pt.Project)
            .HasForeignKey(pt => pt.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);*/

        builder.Entity<Project>()
            .HasOne(p => p.Status)
            .WithMany(ps => ps.Projects)
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}