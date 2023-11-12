﻿using Microsoft.EntityFrameworkCore;
using IdeaBunker.Data;
using IdeaBunker.Areas.Public.Data;
using IdeaBunker.Areas.Private.Data;
using Microsoft.AspNetCore.Identity;
using IdeaBunker.Services;
using IdeaBunker.Areas.Private.Services;
using IdeaBunker.Areas.Public.Services;
using IdeaBunker.Models;

namespace IdeaBunker;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
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

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureContextServices(services);
        ConfigureInterfaceServices(services);

        services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    private void ConfigureContextServices(IServiceCollection services)
    {
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDbContext<PrivateContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDbContext<PublicContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdeaBunkerContextConnection")));
    }

    private static void ConfigureInterfaceServices(IServiceCollection services)
    {
        services.AddScoped<IUserDataService, UserDataService>();
        services.AddScoped<IPrivateDataService, PrivateDataService>();
        services.AddScoped<IPublicDataService, PublicDataService>();
    }
}
