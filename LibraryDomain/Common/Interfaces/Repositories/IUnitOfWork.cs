namespace LibraryDomain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository authorRepository { get; }
        IBookRepository bookRepository { get; }
        IUserRepository userRepository { get; }
        Task<int> Save(CancellationToken cancellationToken);
        Task Rollback();
    }
}
