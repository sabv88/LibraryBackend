using IdentityServer4.Services;
using LibraryIdentity.Data;
using LibraryIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

namespace LibraryIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DbConnection");


            builder.Services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                           .AddEntityFrameworkStores<AuthDbContext>()
                           .AddDefaultTokenProviders();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddIdentityServer()
                .AddAspNetIdentity<AppUser>()
                .AddInMemoryApiResources(Configuration.ApiResources)
                .AddInMemoryIdentityResources(Configuration.IdentityResources)
                .AddInMemoryApiScopes(Configuration.ApiScopes)
                .AddInMemoryClients(Configuration.Clients)
                .AddDeveloperSigningCredential().AddProfileService<ProfileService>();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "LibraryIdentity.Cookie";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });
            builder.Services.AddControllersWithViews();
            var serviceProvider = builder.Services.BuildServiceProvider();
            var context = serviceProvider.GetService<AuthDbContext>();
            var userManager = serviceProvider.GetService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            RoleInitializer.Seed(context, userManager, roleManager)
             .GetAwaiter();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(app.Environment.ContentRootPath, "Styles")),
                RequestPath = "/styles"
            });
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            app.Run();
        }
    }
}