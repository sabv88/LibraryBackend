using MediatR;

namespace LibraryApplication.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDto>
    {
        public Guid Id { get; set; }

    }
}
