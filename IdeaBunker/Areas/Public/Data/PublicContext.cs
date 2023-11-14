using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class PublicContext : PrivateContext
{
    public PublicContext(DbContextOptions<IdentityContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryEvent> CategoryEvents { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentEvent> CommentEvents { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentEvent> DocumentEvents { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectEvent> ProjectEvents { get; set; }
    public DbSet<StatusCategory> StatusCategories { get; set; }
    public DbSet<StatusProject> StatusProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ConfigureCategory(builder);
        ConfigureComment(builder);
        ConfigureDocument(builder);
        ConfigureProject(builder);
        ConfigureSeedData(builder);
    }

    private static void ConfigureCategory(ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasOne(c => c.User)
            .WithMany(u => u.Categories)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Category>()
            .HasOne(c => c.Status)
            .WithMany(s => s.Categories)
            .HasForeignKey(c => c.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureComment(ModelBuilder builder)
    {
        builder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Comment>()
            .HasOne(c => c.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Comment>()
            .HasOne(c => c.ProjectTask)
            .WithMany(pt => pt.Comments)
            .HasForeignKey(c => c.ProjectTaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureDocument(ModelBuilder builder)
    {
        builder.Entity<Document>()
            .HasOne(d => d.User)
            .WithMany(u => u.Documents)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Document>()
            .HasOne(d => d.Project)
            .WithMany(p => p.Documents)
            .HasForeignKey(d => d.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureProject(ModelBuilder builder)
    {
        builder.Entity<Project>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasOne(p => p.Clearance)
            .WithMany(sc => sc.Projects)
            .HasForeignKey(p => p.ClearanceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasOne(p => p.User)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasMany(p => p.ProjectTasks)
            .WithOne(pt => pt.Project)
            .HasForeignKey(pt => pt.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Project>()
            .HasOne(p => p.Status)
            .WithMany(ps => ps.Projects)
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeedData(ModelBuilder builder)
    {
        StatusCategory status = new() { Name = "Unpublished" };
        builder.Entity<StatusCategory>().HasData(
            status,
            new StatusCategory() { Name = "Active" },
            new StatusCategory() { Name = "Approved" },
            new StatusCategory() { Name = "Archive" },
            new StatusCategory() { Name = "Pending" });

        builder.Entity<Category>().HasData(
            new Category() { Name = "Performing Operations, Transporting", StatusId = status.Id, },
            new Category() { Name = "Chemistry, Metallurgy", StatusId = status.Id, },
            new Category() { Name = "Textiles, Paper", StatusId = status.Id, },
            new Category() { Name = "Fixed Constructions", StatusId = status.Id, },
            new Category() { Name = "Mechanical Engineering", StatusId = status.Id, },
            new Category() { Name = "Physics", StatusId = status.Id, },
            new Category() { Name = "Electricity", StatusId = status.Id, });

        builder.Entity<StatusProject>().HasData(
            new StatusProject() { Name = "Active" },
            new StatusProject() { Name = "Approved" },
            new StatusProject() { Name = "Archive" },
            new StatusProject() { Name = "Completed" },
            new StatusProject() { Name = "Denied" },
            new StatusProject() { Name = "Pending" },
            new StatusProject() { Name = "Unpublished" },
            new StatusProject() { Name = "Waitlist" });
    }
}