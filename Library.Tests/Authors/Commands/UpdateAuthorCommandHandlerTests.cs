using LibraryApplication.Authors.Commands.UpdateAuthor;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryTests.Common;

namespace LibraryTests.Authors.Commands
{
    public class UpdateAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateAuthorCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateAuthorCommandHandler(Context);
            var updatedName = "new name";
            var updatedSurname = "new surname";
            var updatedDateOfBirth = DateTime.Now;
            var updatedCountry = "new country";

            // Act
            await handler.Handle(new UpdateAuthorCommand
            {
                Id = LibraryContextFactory.AuthorIdForUpdate,
                Name = updatedName,
                Surname = updatedSurname,
                DateOfBirth = updatedDateOfBirth,
                Country = updatedCountry,
                Books = new List<Book>()
            }, CancellationToken.None);

            // Assert
            var author = await Context.Repository<Author>().GetByIdAsync(LibraryContextFactory.AuthorIdForUpdate);

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
