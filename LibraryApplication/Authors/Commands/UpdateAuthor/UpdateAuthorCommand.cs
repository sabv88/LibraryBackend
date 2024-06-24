using LibraryApplication.DTOs.Authors.Request;
using MediatR;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public record UpdateAuthorCommand(UpdateAuthorDto updateAuthorDto) : IRequest<Unit>;
}
