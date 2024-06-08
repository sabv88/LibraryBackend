using LibraryApplication.Authors.Commands.UpdateAuthor;
using LibraryApplication.Books.Commands.UpdateBook;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryTests.Common;

namespace Library.Tests.Books.Commands
{
    public class UpdateBookCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateBookCommandHandler(Context);
            var updatedISBN = "978-0-201-53082-7";
            var updatedTitle = "new title";
            var updatedGenre = "new genre";
            var updatedDescription = "new description";
            var updatedCount = 11;
            var updatedImagePath = "new path";

            // Act
            await handler.Handle(new UpdateBookCommand
            {
                Id = LibraryContextFactory.BookIdForUpdate,
                ISBN = updatedISBN,
                Title = updatedTitle,
                Genre = updatedGenre,
                Description = updatedDescription,
                Count = updatedCount,
                ImagePath = updatedImagePath,
                Authors = new List<Author>()
            }, CancellationToken.None);

            // Assert
            var book = await Context.Repository<Book>().GetByIdAsync(LibraryContextFactory.BookIdForUpdate);

            Assert.NotNull(book);
            Assert.Equal(book.ISBN, updatedISBN);
            Assert.Equal(book.Title, updatedTitle);
            Assert.Equal(book.Genre, updatedGenre);
            Assert.Equal(book.Count, updatedCount);
            Assert.Equal(book.Description, updatedDescription);
            Assert.Equal(book.ImagePath, updatedImagePath);
        }

        [Fact]
        public async Task UpdateAuthorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateAuthorCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateAuthorCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}

