using AutoMapper;
using LibraryApplication.DTOs.Authors;
using LibraryApplication.DTOs.Book;
using LibraryPersistence;

namespace LibraryTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public UnitOfWork Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = LibraryContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookMappingProfile());
                cfg.AddProfile(new AuthorMappingProfile());
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
