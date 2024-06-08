using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? ImagePath { get; set; }
        public List<Author>? Authors { get; set; }
        public List<User>? Users { get; set; }
    }
}
