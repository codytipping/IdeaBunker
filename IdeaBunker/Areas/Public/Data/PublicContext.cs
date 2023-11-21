using IdeaBunker.Areas.Public.Data;
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
        PublicSeedBuilder.ConfigureSeedData(builder);
    }
}