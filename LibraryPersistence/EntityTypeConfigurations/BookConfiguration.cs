using LibraryDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryPersistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(e => e.Authors)
                     .WithMany(e => e.Books)
                     .UsingEntity(j => j.ToTable("BookAuthor"));
            builder.HasMany(c => c.Users)
            .WithMany(s => s.Books)
            .UsingEntity<Borrow>(
               j => j
                .HasOne(pt => pt.User)
                .WithMany(t => t.Borrows),
            j => j
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Borrows),
            j =>
            {
                j.Property(pt => pt.TakingTime).HasDefaultValue(DateTime.UtcNow);
                j.Property(pt => pt.ReturnTime).HasDefaultValue(DateTime.UtcNow.AddDays(1));
                j.HasKey(t => new { t.Id });
                j.ToTable("Borrow");
            });
        }
    }
}
