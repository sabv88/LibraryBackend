using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IGenericRepository<Book> _repository;
        public BookRepository(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<List<Book>> GetAllAuthorsBooksAsync(Guid authorId)
        {
            return await _repository.Entities.Where(x => x.Id == authorId).ToListAsync();
        }

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.ISBN == isbn);
        }

        public async Task GiveToUser(Guid id)
        {
            var entity = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            entity.Count--;
        }
        public async Task<List<Book>> GetBooksBySearchTitleAsync(string title)
        {
            return await _repository.Entities.Where(x => EF.Functions.Like(x.Title, title)).ToListAsync();
        }
        public async Task<List<Book>> GetBooksByGenreAsync(string genre)
        {
            return await _repository.Entities.Where(x => x.Genre == genre).ToListAsync();
        }
    }
}
