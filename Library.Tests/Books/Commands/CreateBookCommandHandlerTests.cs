using AutoMapper;
using LibraryApplication.Books.Commands.CreateBook;
using LibraryApplication.DTOs.Book.Request;
using LibraryTests.Common;

namespace Library.Tests.Books.Commands
{
    public class CreateBookCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateBookCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreateBookCommandHandler(Context, Mapper);
            var bookISBN = "978-0-201-53082-7";
            var bookTitle = "book title";
            var bookGenre = "book genre";
            var bookDescription = "book description";
            var bookCount = 1;
            var bookImagePath = "book path";

            // Act
            var bookId = await handler.Handle(new CreateBookCommand(
                new CreateBookDto
                {
                    ISBN = bookISBN,
                    Title = bookTitle,
                    Genre = bookGenre,
                    Description = bookDescription,
                    Count = bookCount,
                    ImagePath = bookImagePath,
                    Authors = new List<AuthorForCreateOrUpdatBookDto>()
                }),
                CancellationToken.None);

            // Assert
            var book = await Context.bookRepository.GetByIdAsync(bookId);

            Assert.NotNull(book);
            Assert.Equal(book.ISBN, bookISBN);
            Assert.Equal(book.Title, bookTitle);
            Assert.Equal(book.Genre, bookGenre);
            Assert.Equal(book.Count, bookCount);
            Assert.Equal(book.Description, bookDescription);
            Assert.Equal(book.ImagePath, bookImagePath);
        }
    }
}