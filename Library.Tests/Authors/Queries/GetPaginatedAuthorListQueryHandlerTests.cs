using AutoMapper;
using LibraryTests.Common;
using LibraryApplication.Authors.Queries.GetAuthorListPaginated;
using Shouldly;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Interfaces.Repositories;

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
                new GetPaginatedAuthorListQuery(1, 2),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AuthorPaginatedList>();
            result.Authors.Count.ShouldBe(2);
        }
    }
}
