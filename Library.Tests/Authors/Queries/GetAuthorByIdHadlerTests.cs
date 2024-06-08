using AutoMapper;
using LibraryApplication.Authors.Queries.GetAuthorById;
using LibraryApplication.Repositories;
using LibraryTests.Common;
using Shouldly;

namespace Library.Tests.Authors.Queries
{
    [Collection("QueryCollection")]
    public class GetAuthorByIdHadlerTests
    {
        private readonly IUnitOfWork Context;
        private readonly IMapper Mapper;

        public GetAuthorByIdHadlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAuthorByIdHandler_Success()
        {
            // Arrange
            var handler = new GetAuthorByIdQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetAuthorByIdQuery { Id = Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8") }, CancellationToken.None);
            // Assert
            result.ShouldBeOfType<GetAuthorByIdDto>();
            result.Name.ShouldBe("Name2");
            result.Surname.ShouldBe("Surname2");
            result.Country.ShouldBe("Country2");
        }
    }
}
