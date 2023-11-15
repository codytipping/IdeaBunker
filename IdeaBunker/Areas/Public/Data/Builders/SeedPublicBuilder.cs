using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class SeedPublicBuilder
{ 
    public static void ConfigureSeedData(ModelBuilder builder)
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