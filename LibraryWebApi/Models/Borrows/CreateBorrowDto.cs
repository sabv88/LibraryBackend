namespace LibraryWebApi.Models.Borrows
{
    public class CreateBorrowDto
    {
        public Guid BookId { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
