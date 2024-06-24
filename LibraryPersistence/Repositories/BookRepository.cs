using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Book>> GetAllAuthorsBooksAsync(Guid authorId, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.Where(x => x.Id == authorId).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Book> GetByISBNAsync(string isbn, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.Include(c => c.Authors).FirstOrDefaultAsync(x => x.ISBN == isbn, cancellationToken);
        }

        public async Task<List<Book>> GetBooksBySearchTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.Where(x => EF.Functions.Like(x.Title, title)).AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<List<Book>> GetBooksByGenreAsync(string genre, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.Where(x => x.Genre == genre).AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Book> GetForCheckAsync(Book book, CancellationToken cancellationToken)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(
                x => x.ISBN == book.ISBN &&
                x.Title == book.Title &&
                x.Genre == book.Genre, 
                cancellationToken);
        }
        public async Task AddAuthorsToBook(Book book, List<Author> authors, CancellationToken cancellationToken)
        {
            foreach (var author in authors)
            {
                var entityAuthor = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == author.Id, cancellationToken);
                if (entityAuthor != null)
                {
                    book.Authors.Add(entityAuthor);
                }
            }
        }
    }
}
