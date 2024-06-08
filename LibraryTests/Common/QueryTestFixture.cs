using AutoMapper;
using LibraryApplication.Common.Mappings;
using LibraryApplication.Interfaces;
using LibraryPersistence;
using Xunit;

namespace LibraryTests.Common
{
    internal class QueryTestFixture : IDisposable
    {
        public LibraryDbContext Context;
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
