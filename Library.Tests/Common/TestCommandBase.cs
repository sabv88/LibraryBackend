using LibraryPersistence;

namespace LibraryTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly UnitOfWork Context;

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
