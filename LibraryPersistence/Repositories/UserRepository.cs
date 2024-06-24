using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly LibraryDbContext _dbContext;
        public UserRepository(LibraryDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByIdAsyncWithBorrows(Guid id)
        {
            return await _dbContext.Users.Include(c => c.Books).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
