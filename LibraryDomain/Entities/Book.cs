using LibraryDomain.Common;

namespace LibraryDomain.Entities
{
    public class Book : BaseEntity
    {
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? ImagePath { get; set; }
        public List<Author>? Authors { get; set; } = new();
        public List<User>? Users { get; set; } = new();
        public List<Borrow>? Borrows { get; set; } = new();

    }
}
