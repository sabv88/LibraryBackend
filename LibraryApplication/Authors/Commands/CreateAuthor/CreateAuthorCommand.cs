using LibraryApplication.DTOs.Authors.Request;
using MediatR;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public record CreateAuthorCommand(CreateAuthorDto сreateAuthorDto) : IRequest<Guid>;
}
