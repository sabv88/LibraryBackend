
using FluentValidation;

namespace LibraryApplication.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommandValidator: AbstractValidator<CreateBorrowCommand>
    {
      public  CreateBorrowCommandValidator() 
        {
            RuleFor(createAuthorCommand =>
                  createAuthorCommand.UserId).NotNull().NotEmpty();
            RuleFor(createAuthorCommand =>
                createAuthorCommand.createBorrowDto.BookId).NotNull().NotEmpty();
            RuleFor(createAuthorCommand =>
                createAuthorCommand.createBorrowDto.ReturnTime).NotNull().NotEqual(DateTime.MinValue);
        }
    }
}
