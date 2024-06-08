using LibraryDomain.Common.Interfaces;

namespace LibraryDomain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
