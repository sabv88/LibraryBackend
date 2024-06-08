using LibraryApplication.Authors.Commands.DeleteAuthor;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryTests.Common;

namespace LibraryTests.Authors.Commands
{
    public class DeleteAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteAuthorCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteAuthorCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteAuthorCommand
            {
                Id = LibraryContextFactory.AuthorIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Repository<Author>().GetByIdAsync(LibraryContextFactory.AuthorIdForDelete));
        }

        [Fact]
        public async Task DeleteAuthorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteAuthorCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteAuthorCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}
