using LibraryApplication.DTOs.Authors;
using LibraryApplication.DTOs.Book;
using LibraryApplication.DTOs.Borrows;
using LibraryApplication.DTOs.Users;

namespace LibraryWebApi.Services
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookMappingProfile), typeof(AuthorMappingProfile), typeof(BorrowMappingProfile), typeof(UserMappingProfile));
            return services;
        }
    }
}
