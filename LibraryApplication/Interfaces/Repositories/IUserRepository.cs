using LibraryDomain.Entities;

namespace LibraryApplication.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);

    }
}
