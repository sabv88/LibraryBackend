using LibraryDomain.Common;

namespace LibraryDomain.Entities
{
    public class Borrow : BaseEntity
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public Book? Book { get; set; }
        public User? User { get; set; }
        public bool? Returned { get; set; } = false;
        public DateTime TakingTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
