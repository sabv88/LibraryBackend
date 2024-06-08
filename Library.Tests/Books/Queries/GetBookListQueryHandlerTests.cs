using AutoMapper;
using LibraryApplication.Books.Queries.GetBookList;
using LibraryApplication.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetBookListQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetBookListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetBookListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetBookListQuery(),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BookList>();
            result.Books.Count.ShouldBe(4);
        }
    }
}
