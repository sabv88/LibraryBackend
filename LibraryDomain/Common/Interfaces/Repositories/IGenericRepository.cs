using LibraryDomain.Common;

namespace LibraryDomain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T :  BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetPaginatedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    }
}
