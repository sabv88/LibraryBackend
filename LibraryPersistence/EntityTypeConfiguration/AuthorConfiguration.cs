using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryDomain.Entities;

namespace LibraryPersistence.EntityTypeConfiguration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(Author => Author.Id);
            builder.HasIndex(Author => Author.Id).IsUnique();
        }
    }
}
