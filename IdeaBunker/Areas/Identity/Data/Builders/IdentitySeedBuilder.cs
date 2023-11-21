using IdeaBunker.Areas.Identity.Models;
using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class IdentitySeedBuilder
{
    public static void ConfigureSeedData(ModelBuilder builder)
    {
        builder.Entity<Rank>().HasData(new Rank() { Name = "Default" });
    }
}