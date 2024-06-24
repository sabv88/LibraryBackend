using LibraryDomain.Common;
using LibraryDomain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly LibraryDbContext _dbContext;

        public GenericRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext
                .Set<T>().AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetPaginatedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _dbContext
                .Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
