using LibraryTests.Common;
using Xunit;

namespace LibraryTests.Authors.Commands
{
    public class CreateAuthorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFlourCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateFlourCommandHandler(Context);
            var flourName = "flour name";

            // Act
            var flourId = await handler.Handle(
                new CreateFlourCommand
                {
                    Name = flourName,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Flours.SingleOrDefaultAsync(flour =>
                    flour.Id == flourId && flour.Name == flourName));
        }
    }
}