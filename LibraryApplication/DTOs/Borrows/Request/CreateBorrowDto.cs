namespace LibraryApplication.DTOs.Borrows.Request
{
    public class CreateBorrowDto
    {
        public Guid BookId { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
