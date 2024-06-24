using MediatR;

namespace LibraryApplication.Authors.Commands.DeleteAuthor
{
    public record DeleteAuthorCommand(Guid Id) : IRequest<Unit>;
}