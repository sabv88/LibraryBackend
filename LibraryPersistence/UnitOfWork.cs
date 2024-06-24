using LibraryDomain.Interfaces.Repositories;
using LibraryPersistence.Repositories;

namespace LibraryPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;

        private IAuthorRepository _authorRepository { get; set; }
        private IBookRepository _bookRepository { get; set; }
        private IUserRepository _userRepository { get; set; }

        private bool disposed;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBookRepository bookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_dbContext);
                return _bookRepository;
            }
        }

        public IAuthorRepository authorRepository
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository(_dbContext);
                return _authorRepository;
            }
        }
        public IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);
                return _userRepository;
            }
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
