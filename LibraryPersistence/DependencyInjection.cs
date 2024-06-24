using LibraryDomain.Interfaces.Repositories;
using LibraryPersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryPersistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
         services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IAuthorRepository, AuthorRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
