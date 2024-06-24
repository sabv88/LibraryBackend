using AutoMapper;
using LibraryApplication.Authors.Commands.CreateAuthor;
using LibraryApplication.DTOs.Authors.Request;
using LibraryDomain.Interfaces.Repositories;
using LibraryTests.Common;

namespace LibraryTests.Authors.Commands
{
    [Collection("QueryCollection")]
    public class CreateAuthorCommandHandlerTests : TestCommandBase
    {
        private readonly IMapper Mapper;
        public CreateAuthorCommandHandlerTests(QueryTestFixture fixture)
        {
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task CreateAuthorCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreateAuthorCommandHandler(Context, Mapper);
            var authorName = "author name";
            var authorSurname = "author surname";
            var authorDateOfBirth = DateTime.Now;
            var authorCountry = "author country";
            // Act
            var authorDto = new CreateAuthorDto
            {
                Name = authorName,
                Surname = authorSurname,
                Country = authorCountry,
                DateOfBirth = authorDateOfBirth,
                Books = new List<BookForCreateOrUpdateAuthorDto>()
            };

            var authorId = await handler.Handle(new CreateAuthorCommand(authorDto), CancellationToken.None);

            // Assert
            var author = await Context.authorRepository.GetByIdAsync(authorId);

            Assert.NotNull(author);
            Assert.Equal(author.Name, authorName);
            Assert.Equal(author.Country, authorCountry);
            Assert.Equal(author.Surname, authorSurname);
            Assert.Equal(author.DateOfBirth, authorDateOfBirth);
        }
    }
}
