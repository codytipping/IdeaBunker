using Microsoft.EntityFrameworkCore;
using IdeaBunker.Data;
using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Areas.Identity.Models.Entities;
using IdeaBunker.Areas.Private.Data;

namespace IdeaBunker;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }   

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDbContext<PrivateContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDbContext<PublicContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<IdentityContext>();
        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            //app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }
}
