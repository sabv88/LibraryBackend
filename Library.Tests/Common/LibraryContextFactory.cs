using LibraryDomain.Entities;
using LibraryPersistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryTests.Common
{
    public static class LibraryContextFactory
    {
        public static Guid AuthorAId = Guid.NewGuid();
        public static Guid AuthorBId = Guid.NewGuid();
        public static Guid AuthorIdForDelete = Guid.NewGuid();
        public static Guid AuthorIdForUpdate = Guid.NewGuid();

        public static Guid BookAId = Guid.NewGuid();
        public static Guid BookBId = Guid.NewGuid();
        public static Guid BookIdForDelete = Guid.NewGuid();
        public static Guid BookIdForUpdate = Guid.NewGuid();

        public static UnitOfWork Create()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new LibraryDbContext(options);
            context.Database.EnsureCreated();
            context.Authors.AddRange(
                new Author
                {
                    Id = Guid.Parse("45492178-69F7-448A-96F5-7D4DDDB6F43F"),
                    Name = "Name1",
                    Surname = "Surname1",
                    DateOfBirth = DateTime.Now,
                    Country = "Country1"
                },
                new Author
                {
                    Id = Guid.Parse("A88661F1-5516-445E-8C28-BBC2549EDAB8"),
                    Name = "Name2",
                    Surname = "Surname2",
                    DateOfBirth = DateTime.Now.AddYears(-5),
                    Country = "Country2"
                },
                new Author
                {
                    Id = AuthorIdForDelete,
                    Name = "Name3",
                    Surname = "Surname3",
                    DateOfBirth = DateTime.Now.AddYears(-10),
                    Country = "Country3"
                },
                new Author
                {
                    Id = AuthorIdForUpdate,
                    Name = "Name4",
                    Surname = "Surname4",
                    DateOfBirth = DateTime.Now,
                    Country = "Country4"
                }
            );

            context.Books.AddRange(
                new Book
                {
                    Id = Guid.Parse("0078E21D-B9B7-47F8-9B8D-9D38F694C5B3"),
                    ISBN = "978-1-56619-909-4",
                    Title = "Title1",
                    Genre = "Genre1",
                    Description = "Description1",
                    Count = 1,
                    ImagePath = string.Empty,
                },
                new Book
                {
                    Id = Guid.Parse("AC2818E0-FF27-46D7-9183-CC2D39E3130F"),
                    ISBN = "978-3-16-148410-0",
                    Title = "Title2",
                    Genre = "Genre2",
                    Description = "Description2",
                    Count = 2,
                    ImagePath = string.Empty,
                },
                new Book
                {
                    Id = BookIdForDelete,
                    ISBN = "978-3-16-148410-0",
                    Title = "Title3",
                    Genre = "Genre3",
                    Description = "Description3",
                    Count = 3,
                    ImagePath = string.Empty,
                },
                new Book
                {
                    Id = BookIdForUpdate,
                    ISBN = "978-0-399-21485-8",
                    Title = "Title4",
                    Genre = "Genre4",
                    Description = "Description4",
                    Count = 4,
                    ImagePath = string.Empty,
                }
            );
            context.SaveChanges();

            return new UnitOfWork(context);
        }

        public static void Destroy(UnitOfWork context)
        {
            context.Dispose();
        }

    }
}
