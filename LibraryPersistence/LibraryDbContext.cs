using LibraryDomain.Entities;
using LibraryPersistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistence
{
    public class LibraryDbContext : DbContext
    {
       public DbSet<Author> Authors { get; set; }
       public DbSet<Book> Books { get; set; }
       public DbSet<Borrow> Borrows { get; set; }
       public DbSet<User> Users { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

