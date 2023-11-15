using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class SeedPrivateBuilder
{
    public static void ConfigurePrivateSeedData(ModelBuilder builder)
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