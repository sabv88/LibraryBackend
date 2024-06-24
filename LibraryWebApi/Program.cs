using Serilog;
using System.Text.Json.Serialization;
using LibraryWebApi.Services;
using LibraryWebApi.Middleware;
using LibraryPersistence;
using LibraryApplication.Interfaces;
using LibraryApplication;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

// Add services to the container.
namespace LibraryWeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger.Configure();
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMapper();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Host.UseSerilog();
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            builder.Services.AddAuthenticationConfigure();
            builder.Services.AddAuthorizationConfigure();
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                    ConfigureSwaggerOptions>();
            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Library API");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}