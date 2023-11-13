using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public class Context : PublicContext
{
    public Context(DbContextOptions<IdentityContext> options) : base(options) { }
}