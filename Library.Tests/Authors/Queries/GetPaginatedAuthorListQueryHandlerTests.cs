using AutoMapper;
using LibraryApplication.Repositories;
using LibraryTests.Common;
using LibraryApplication.Authors.Queries.GetAuthorListPaginated;
using Shouldly;

namespace Library.Tests.Authors.Queries
{
    [Collection("QueryCollection")]
    public class GetPaginatedAuthorListQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetPaginatedAuthorListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPaginatedAuthorListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPaginatedAuthorListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPaginatedAuthorListQuery { PageNumber = 1, PageSize = 2},
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AuthorPaginatedList>();
            result.Authors.Count.ShouldBe(2);
        }
    }
}
