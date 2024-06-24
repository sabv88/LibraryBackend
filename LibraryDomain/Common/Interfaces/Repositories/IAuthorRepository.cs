using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces.Repositories
{ 
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetForCheckAsync(Author author, CancellationToken cancellationToken);
        Task AddBooksToAuthor(Author author, List<Book> books, CancellationToken cancellationToken);
    }
}
