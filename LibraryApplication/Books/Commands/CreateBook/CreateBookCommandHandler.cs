using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                ISBN = request.ISBN,
                Title = request.Title,
                Genre = request.Genre,
                Description = request.Description,
                Count = request.Count,
                ImagePath = request.ImagePath,
                Authors = new List<Author>(),
            };
            await _unitOfWork.Repository<Book>().AddAsync(book);

            foreach (var author in request.Authors)
            {
                var entityAuthor = await _unitOfWork.Repository<Author>().GetByIdAsync(author.Id);
                if (entityAuthor != null)
                {
                    book.Authors.Add(entityAuthor);
                }
            }
            await _unitOfWork.Save(cancellationToken);

            return book.Id;
        }
    }
}