using IdeaBunker.Areas.Public.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Data;

public class PublicSeedBuilder
{
    public static void ConfigureSeedData(ModelBuilder builder)
    {
        CategoryStatus status = new() { Name = "Unpublished" };
        builder.Entity<CategoryStatus>().HasData(
            status,
            new CategoryStatus() { Name = "Active" },
            new CategoryStatus() { Name = "Approved" },
            new CategoryStatus() { Name = "Archive" },
            new CategoryStatus() { Name = "Pending" });

        builder.Entity<Category>().HasData(
            new Category() { Name = "Performing Operations, Transporting", StatusId = status.Id, },
            new Category() { Name = "Chemistry, Metallurgy", StatusId = status.Id, },
            new Category() { Name = "Textiles, Paper", StatusId = status.Id, },
            new Category() { Name = "Fixed Constructions", StatusId = status.Id, },
            new Category() { Name = "Mechanical Engineering", StatusId = status.Id, },
            new Category() { Name = "Physics", StatusId = status.Id, },
            new Category() { Name = "Electricity", StatusId = status.Id, });

        builder.Entity<ProjectStatus>().HasData(
            new ProjectStatus() { Name = "Active" },
            new ProjectStatus() { Name = "Approved" },
            new ProjectStatus() { Name = "Archive" },
            new ProjectStatus() { Name = "Completed" },
            new ProjectStatus() { Name = "Denied" },
            new ProjectStatus() { Name = "Pending" },
            new ProjectStatus() { Name = "Unpublished" },
            new ProjectStatus() { Name = "Waitlist" });
    }
}