using AutoMapper;
using LibraryApplication.Common.Mappings;
using LibraryApplication.Interfaces;
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
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ILibraryDbContext).Assembly));
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
