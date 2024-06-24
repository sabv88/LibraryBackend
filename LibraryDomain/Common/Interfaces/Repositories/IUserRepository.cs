using LibraryDomain.Entities;

namespace LibraryDomain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByIdAsyncWithBorrows(Guid id);
    }
}
