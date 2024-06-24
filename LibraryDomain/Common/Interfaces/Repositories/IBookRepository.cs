using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetByISBNAsync(string isbn, CancellationToken cancellationToken);
        Task<List<Book>> GetAllAuthorsBooksAsync(Guid authorId, CancellationToken cancellationToken);
        Task<List<Book>> GetBooksBySearchTitleAsync(string title, CancellationToken cancellationToken);
        Task<List<Book>> GetBooksByGenreAsync(string title, CancellationToken cancellationToken);
        Task<Book> GetForCheckAsync(Book book, CancellationToken cancellationToken);
        Task AddAuthorsToBook(Book book, List<Author> authors, CancellationToken cancellationToken);
    }
}
