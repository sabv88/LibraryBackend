using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LibraryWebApi.Services
{
    public static class ConfigureAuthentication
    {
        public static IServiceCollection AddAuthenticationConfigure(this IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7287/";
                options.Audience = "LibraryWebAPI";
                options.RequireHttpsMetadata = false;
            });
            return services;
        }
    }
}
