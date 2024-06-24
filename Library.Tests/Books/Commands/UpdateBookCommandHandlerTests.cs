using AutoMapper;
using LibraryApplication.Books.Commands.UpdateBook;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Book.Request;
using LibraryTests.Common;

namespace Library.Tests.Books.Commands
{
    public class UpdateBookCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task UpdateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateBookCommandHandler(Context, Mapper);
            var updatedISBN = "978-0-201-53082-7";
            var updatedTitle = "new title";
            var updatedGenre = "new genre";
            var updatedDescription = "new description";
            var updatedCount = 11;
            var updatedImagePath = "new path";

            // Act
            await handler.Handle(new UpdateBookCommand(new UpdateBookDto
            {
                Id = LibraryContextFactory.BookIdForUpdate,
                ISBN = updatedISBN,
                Title = updatedTitle,
                Genre = updatedGenre,
                Description = updatedDescription,
                Count = updatedCount,
                ImagePath = updatedImagePath,
            }), CancellationToken.None);

            // Assert
            var book = await Context.bookRepository.GetByIdAsync(LibraryContextFactory.BookIdForUpdate);

            Assert.NotNull(book);
            Assert.Equal(book.ISBN, updatedISBN);
            Assert.Equal(book.Title, updatedTitle);
            Assert.Equal(book.Genre, updatedGenre);
            Assert.Equal(book.Count, updatedCount);
            Assert.Equal(book.Description, updatedDescription);
            Assert.Equal(book.ImagePath, updatedImagePath);
        }

        [Fact]
        public async Task UpdateBookCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateBookCommandHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateBookCommand(new UpdateBookDto()),
                    CancellationToken.None));
        }
    }
}

