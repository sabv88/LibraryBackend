using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
