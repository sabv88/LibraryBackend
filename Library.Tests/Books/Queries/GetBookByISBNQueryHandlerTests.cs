using AutoMapper;
using LibraryApplication.Books.Queries.GetBookById;
using LibraryApplication.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookByISBNQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetBookByISBNQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookByISBNHandler_Success()
        {
            // Arrange
            var handler = new GetBookByIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBookByIdQuery { Id = Guid.Parse("0078E21D-B9B7-47F8-9B8D-9D38F694C5B3") }, CancellationToken.None);
            // Assert
            result.ShouldBeOfType<GetBookByIdDto>();
            result.ISBN.ShouldBe("978-1-56619-909-4");
            result.Title.ShouldBe("Title1");
            result.Genre.ShouldBe("Genre1");
            result.Description.ShouldBe("Description1");
            result.Count.ShouldBe(1);
            result.ImagePath.ShouldBe(string.Empty);
        }
    }
}
