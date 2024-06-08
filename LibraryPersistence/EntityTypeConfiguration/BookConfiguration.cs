using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryDomain.Entities;

namespace LibraryPersistence.EntityTypeConfiguration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(Book => Book.Id);
            builder.HasIndex(Book => Book.Id).IsUnique();
        }
    }
}
