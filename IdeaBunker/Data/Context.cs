using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context 
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        IdentityContext(builder);
        //PrivateContext(builder);
        PublicContext(builder);
    }
}