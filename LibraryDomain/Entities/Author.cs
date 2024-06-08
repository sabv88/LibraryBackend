using LibraryDomain.Common;

namespace LibraryDomain.Entities
{
    public class Author : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<Book>? Books { get; set; } = new();

    }
}
