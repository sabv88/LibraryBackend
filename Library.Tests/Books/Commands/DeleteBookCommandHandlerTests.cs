using LibraryApplication.Books.Commands.DeleteBook;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryTests.Common;

namespace Library.Tests.Books.Commands
{
    public class DeleteBookCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteBookCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteBookCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteBookCommand
            {
                Id = LibraryContextFactory.BookIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Repository<Book>().GetByIdAsync(LibraryContextFactory.BookIdForDelete));
        }

        [Fact]
        public async Task DeleteBookCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteBookCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteBookCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}