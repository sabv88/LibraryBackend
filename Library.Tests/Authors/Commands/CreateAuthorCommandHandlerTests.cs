using LibraryApplication.Authors.Commands.CreateAuthor;
using LibraryDomain.Entities;
using LibraryTests.Common;

namespace LibraryTests.Authors.Commands
{
    public class CreateAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateAuthorCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreateAuthorCommandHandler(Context);
            var authorName = "author name";
            var authorSurname = "author surname";
            var authorDateOfBirth = DateTime.Now;
            var authorCountry = "author country";
            // Act
            var authorId = await handler.Handle(
                new CreateAuthorCommand
                {
                    Name = authorName,
                    Surname = authorSurname,
                    Country = authorCountry,
                    DateOfBirth = authorDateOfBirth,
                    Books = new List<Book>()
                },
                CancellationToken.None);

            // Assert
            var author = await Context.Repository<Author>().GetByIdAsync(authorId);

            Assert.NotNull(author);
            Assert.Equal(author.Name, authorName);
            Assert.Equal(author.Country, authorCountry);
            Assert.Equal(author.Surname, authorSurname);
            Assert.Equal(author.DateOfBirth, authorDateOfBirth);
        }
    }
}
