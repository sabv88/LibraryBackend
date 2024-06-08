using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<Book>? Books { get; set; }
    }
}
