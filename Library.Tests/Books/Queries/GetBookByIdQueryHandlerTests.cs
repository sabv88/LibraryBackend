using AutoMapper;
using LibraryApplication.Books.Queries.GetBookById;
using LibraryApplication.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookByIdQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetBookByIdQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookByIdHandler_Success()
        {
            // Arrange
            var handler = new GetBookByIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBookByIdQuery { Id = Guid.Parse("AC2818E0-FF27-46D7-9183-CC2D39E3130F") }, CancellationToken.None);
            // Assert
            result.ShouldBeOfType<GetBookByIdDto>();
            result.ISBN.ShouldBe("978-3-16-148410-0");
            result.Title.ShouldBe("Title2");
            result.Genre.ShouldBe("Genre2");
            result.Description.ShouldBe("Description2");
            result.Count.ShouldBe(2);
            result.ImagePath.ShouldBe(string.Empty);
        }
    }
}
