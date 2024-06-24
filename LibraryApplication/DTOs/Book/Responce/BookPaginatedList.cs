using MediatR;

namespace LibraryApplication.DTOs.Book.Responce
{
    public class BookPaginatedList : IRequest<BookPaginatedList>
    {
        public IList<BookPaginatedDto>? Books { get; set; }
    }
}
