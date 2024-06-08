using LibraryDomain.Entities;

namespace LibraryApplication.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByISBNAsync(string isbn);
        Task<List<Book>> GetAllAuthorsBooksAsync(Guid authorId);
        Task<List<Book>> GetBooksBySearchTitleAsync(string title);
        Task<List<Book>> GetBooksByGenreAsync(string title);
        Task GiveToUser(Guid id);
    }
}
