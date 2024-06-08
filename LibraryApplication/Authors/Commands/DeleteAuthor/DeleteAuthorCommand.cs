using MediatR;

namespace LibraryApplication.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}