using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class ProjectTaskBuilder
{
    public static void ConfigureProjectTask(ModelBuilder builder)
    {
        builder.Entity<ProjectTask>()
           .HasOne(pt => pt.User)
           .WithMany(u => u.ProjectTasks)
           .HasForeignKey(pt => pt.UserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ProjectTask>()
            .HasOne(pt => pt.Status)
            .WithMany(s => s.ProjectTasks)
            .HasForeignKey(pt => pt.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}