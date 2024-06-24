using AutoMapper;
using LibraryApplication.DTOs.Authors;
using LibraryApplication.DTOs.Book;
using LibraryPersistence;

namespace LibraryTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly UnitOfWork Context;
        protected readonly IMapper Mapper;

        public TestCommandBase()
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
}
