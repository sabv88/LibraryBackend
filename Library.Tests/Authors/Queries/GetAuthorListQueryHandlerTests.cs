using AutoMapper;
using LibraryApplication.Authors.Queries.GetAuthorList;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Interfaces.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Authors.Queries
{
    [Collection("QueryCollection")]
    public class GetAuthorListQueryHandlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetAuthorListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAuthorListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAuthorListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetAuthorListQuery (),
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<AuthorList>();
            result.Authors.Count.ShouldBe(4);
        }
    }
}
