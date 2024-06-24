using AutoMapper;
using LibraryApplication.Books.Queries.GetBookListPaginated;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Books.Queries
{
    [Collection("QueryCollection")]
    public class GetPaginatedBookListQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetPaginatedBookListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPaginatedBookListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPaginatedBookListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPaginatedBookListQuery (1, 2),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<BookPaginatedList>();
            result.Books.Count.ShouldBe(2);
        }
    }
}
