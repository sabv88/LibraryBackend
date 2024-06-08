using LibraryApplication.Repositories;
using LibraryDomain.Entities;

namespace LibraryPersistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IGenericRepository<Author> _repository;
        public AuthorRepository(IGenericRepository<Author> repository) 
        { 
            _repository = repository;
        }
    }
}
