using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class SeedIdentityBuilder
{
    public static void ConfigureSeedData(ModelBuilder builder)
    {
        builder.Entity<Rank>().HasData(new Rank() { Name = "Default" });
    }
}