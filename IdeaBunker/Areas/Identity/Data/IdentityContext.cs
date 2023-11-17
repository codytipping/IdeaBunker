using IdeaBunker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdeaBunker.Data;

public partial class Context : IdentityDbContext<User> 
{ 
    public void IdentityContext(ModelBuilder builder)
    {
        IdentityBuilder.ConfigureIdentity(builder);
        //RoleBuilder.ConfigureRole(builder);
        //UserBuilder.ConfigureUser(builder);
        SeedIdentityBuilder.ConfigureSeedData(builder);
    }
}