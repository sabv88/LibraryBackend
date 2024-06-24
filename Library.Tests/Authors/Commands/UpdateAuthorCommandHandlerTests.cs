using LibraryApplication.Authors.Commands.UpdateAuthor;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Authors.Request;
using LibraryTests.Common;

namespace LibraryTests.Authors.Commands
{
    public class UpdateAuthorCommandHandlerTests : TestCommandBase
    {

        [Fact]
        public async Task UpdateAuthorCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateAuthorCommandHandler(Context, Mapper);
            var updatedName = "new name";
            var updatedSurname = "new surname";
            var updatedDateOfBirth = DateTime.Now;
            var updatedCountry = "new country";

            // Act
            await handler.Handle(new UpdateAuthorCommand(new UpdateAuthorDto
            {
                Id = LibraryContextFactory.AuthorIdForUpdate,
                Name = updatedName,
                Surname = updatedSurname,
                DateOfBirth = updatedDateOfBirth,
                Country = updatedCountry,
                Books = new List<BookForCreateOrUpdateAuthorDto>()
            }), CancellationToken.None);

            // Assert
            var author = await Context.authorRepository.GetByIdAsync(LibraryContextFactory.AuthorIdForUpdate);

            Assert.NotNull(author);
            Assert.Equal(author.Name, updatedName);
            Assert.Equal(author.Country, updatedCountry);
            Assert.Equal(author.Surname, updatedSurname);
            Assert.Equal(author.DateOfBirth, updatedDateOfBirth);
        }

        [Fact]
        public async Task UpdateAuthorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateAuthorCommandHandler(Context, Mapper);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateAuthorCommand(new UpdateAuthorDto()), 
                    CancellationToken.None));
        }
    }
}
