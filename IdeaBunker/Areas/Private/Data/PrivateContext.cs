using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class PrivateContext : IdentityContext
{
    public PrivateContext(DbContextOptions<IdentityContext> options) : base(options) { }

    public DbSet<Clearance> Clearances { get; set; }
    public DbSet<Directorate> Directorates { get; set; }
    public DbSet<DirectorateEvent> DirectorateEvents { get; set; }
    public DbSet<DirectorateProject> DirectorateProjects { get; set; }
    public DbSet<DirectorateRole> DirectorateRoles { get; set; } 
    public DbSet<DirectorateUser> DirectorateUsers { get; set; }    
    public DbSet<Division> Divisions { get; set; }
    public DbSet<DivisionEvent> DivisionEvents { get; set; }
    public DbSet<DivisionProject> DivisionProjects { get; set; }
    public DbSet<DivisionRole> DivisionRoles { get; set; }
    public DbSet<DivisionUser> DivisionUsers { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<ProjectTaskEvent> ProjectTasksEvents { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<SectionEvent> SectionEvents { get; set; }
    public DbSet<SectionProject> SectionProjects { get; set; }
    public DbSet<SectionRole> SectionRoles { get; set; }
    public DbSet<SectionUser> SectionUsers { get; set; }
    public DbSet<StatusProjectTask> StatusProjectTasks { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamEvent> TeamsEvents { get; set; }
    public DbSet<TeamProject> TeamProjects { get; set; }
    public DbSet<TeamRole> TeamRoles { get; set; }
    public DbSet<TeamUser> TeamUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ConfigureDirectorate(builder);
        ConfigureDivision(builder);
        ConfigureProjectTask(builder);
        ConfigureSection(builder);
        ConfigureSeedData(builder);
        ConfigureTeam(builder);   
    }

    private static void ConfigureDirectorate(ModelBuilder builder)
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

    private static void ConfigureDivision(ModelBuilder builder)
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

    private static void ConfigureProjectTask(ModelBuilder builder)
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

    private static void ConfigureSection(ModelBuilder builder)
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

    private static void ConfigureTeam(ModelBuilder builder)
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

    private static void ConfigureSeedData(ModelBuilder builder)
    {
        builder.Entity<Clearance>().HasData(
           new Clearance() { Name = "No Clearance" },
           new Clearance() { Name = "Secret Clearance" },
           new Clearance() { Name = "Top Secret Clearance" },
           new Clearance() { Name = "Top Secret Clearance SCI" },
           new Clearance() { Name = "Top Secret Clearance SAP" });

        builder.Entity<StatusProjectTask>().HasData(
            new StatusProjectTask() { Name = "Active" },
            new StatusProjectTask() { Name = "Archive" },
            new StatusProjectTask() { Name = "Complete" },
            new StatusProjectTask() { Name = "Waitlist" });
    }
}