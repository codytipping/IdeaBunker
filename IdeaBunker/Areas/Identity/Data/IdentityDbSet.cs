using IdeaBunker.Models;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<RoleEvent> RolesEvent { get; set; }
    public DbSet<UserEvent> UsersEvent { get; set; }
}