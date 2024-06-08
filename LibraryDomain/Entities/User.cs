using LibraryDomain.Common;

namespace LibraryDomain.Entities
{
    public class User : BaseEntity
    {
        public List<Book>? Books { get; set; } = new();
        public List<Borrow>? Borrows { get; set; } = new();
    }
}
