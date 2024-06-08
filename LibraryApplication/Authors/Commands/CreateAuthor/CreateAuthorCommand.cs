using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<Book>? Books { get; set; }
    }
}
