﻿using Microsoft.EntityFrameworkCore;
using IdeaBunker.Data;
using Microsoft.AspNetCore.Identity;
using IdeaBunker.Services;
using IdeaBunker.Models;
using IdeaBunker.Areas.Identity.Services;

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
            app.UseMigrationsEndPoint();
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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {      
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ContextConnection")));
        services.AddScoped<IDataService, DataService>();
        services.AddScoped<IUserLockoutService, UserLockoutService>();       
        services.AddScoped<IEventService, EventService>();  
        services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
        services.AddControllersWithViews();
        services.AddRazorPages();
    }
}