using IdeaBunker.Areas.Public.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Areas.Public.Data;

public class DocumentBuilder
{
    public static void ConfigureDocument(ModelBuilder builder)
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
}