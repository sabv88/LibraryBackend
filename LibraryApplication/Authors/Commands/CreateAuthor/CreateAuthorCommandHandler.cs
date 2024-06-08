using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var Author = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Country = request.Country,
                Books = new List<Book>(),
            };
            await _unitOfWork.Repository<Author>().AddAsync(Author);

            foreach (var book in request.Books)
            {
                var entityBook = await _unitOfWork.Repository<Book>().GetByIdAsync(book.Id);
                if(entityBook != null)
                {
                    Author.Books.Add(entityBook);
                }
            }

            await _unitOfWork.Save(cancellationToken);

            return Author.Id;
        }
    }
}