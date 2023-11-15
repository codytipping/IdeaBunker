using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class TeamBuilder
{
    public static void ConfigureTeam(ModelBuilder builder)
    {
        builder.Entity<TeamProject>().HasKey(tp => new { tp.ProjectId, tp.TeamId });
        builder.Entity<TeamRole>().HasKey(tr => new { tr.RoleId, tr.TeamId });
        builder.Entity<TeamUser>().HasKey(tu => new { tu.UserId, tu.TeamId });

        builder.Entity<TeamProject>()
           .HasOne(tp => tp.Team)
           .WithMany(p => p.TeamProjects)
           .HasForeignKey(tp => tp.TeamId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TeamProject>()
            .HasOne(tp => tp.Project)
            .WithMany(p => p.TeamProjects)
            .HasForeignKey(tp => tp.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TeamRole>()
            .HasOne(tr => tr.Team)
            .WithMany(t => t.TeamRoles)
            .HasForeignKey(tr => tr.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TeamRole>()
            .HasOne(tr => tr.Role)
            .WithMany(u => u.TeamRoles)
            .HasForeignKey(tr => tr.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TeamUser>()
            .HasOne(tu => tu.Team)
            .WithMany(t => t.TeamUsers)
            .HasForeignKey(tu => tu.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TeamUser>()
            .HasOne(tu => tu.User)
            .WithMany(u => u.TeamUsers)
            .HasForeignKey(tu => tu.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}