namespace LibraryWebApi.Services
{
    public static class ConfigureAuthorization
    {
        public static IServiceCollection AddAuthorizationConfigure(
            this IServiceCollection services)
        {
            services.AddAuthorization(options =>
             {
                 options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                 options.AddPolicy("User", policy => policy.RequireRole("User"));
             });
            return services;
        }
    }
}
