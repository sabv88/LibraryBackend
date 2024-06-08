using LibraryApplication.Interfaces.Repositories;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _repository;
        public UserRepository(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repository.Entities.Include(c=>c.Books).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
