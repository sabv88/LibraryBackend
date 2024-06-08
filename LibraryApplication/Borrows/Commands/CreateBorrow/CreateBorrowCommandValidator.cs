
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
                createAuthorCommand.BookId).NotNull().NotEmpty();
            RuleFor(createAuthorCommand =>
                createAuthorCommand.TakingTime).NotNull().NotEqual(DateTime.MinValue);
            RuleFor(createAuthorCommand =>
               createAuthorCommand.ReturnTime).NotNull().GreaterThan(createAuthorCommand =>
               createAuthorCommand.TakingTime);
        }
    }
}
