using LibraryApplication.Interfaces;
using LibraryDomain.Entities;
using LibraryPersistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
       public DbSet<Author> Authors { get; set; }
       public DbSet<Book> Books { get; set; }
       public DbSet<Borrow> Borrows { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.Entity<Book>()
                    .HasMany(e => e.Authors)
                    .WithMany(e => e.Books)
                    .UsingEntity(j => j.ToTable("BookAuthor"));
            modelBuilder.Entity<Book>()
            .HasMany(c => c.Users)
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

