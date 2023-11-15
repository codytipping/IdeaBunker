using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context
{
    public void PublicContext(ModelBuilder builder)
    {
        CategoryBuilder.ConfigureCategory(builder);
        CommentBuilder.ConfigureComment(builder);
        DocumentBuilder.ConfigureDocument(builder);
        ProjectBuilder.ConfigureProject(builder);
        SeedPublicBuilder.ConfigureSeedData(builder);
    }
}