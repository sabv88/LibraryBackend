using LibraryPersistence;

namespace LibraryTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly LibraryDbContext Context;

        public TestCommandBase()
        {
            Context = LibraryContextFactory.Create();
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }
}
