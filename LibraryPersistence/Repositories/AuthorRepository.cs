using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorRepository(LibraryDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetForCheckAsync(Author author, CancellationToken cancellationToken)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(
                x => x.Name == author.Name &&
                x.Surname == author.Surname &&
                x.DateOfBirth == author.DateOfBirth &&
                x.Country == author.Country,
                cancellationToken);
        }
        public async Task AddBooksToAuthor(Author author, List<Book> books, CancellationToken cancellationToken)
        {
            foreach (var book in books)
            {
                var entityBook = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == book.Id, cancellationToken);
                if (entityBook != null)
                {
                    author.Books.Add(entityBook);
                    _dbContext.Books.Attach(entityBook);
                }
            }
        }
    }
}
