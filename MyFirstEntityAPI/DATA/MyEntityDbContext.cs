using Microsoft.EntityFrameworkCore;
using MyFirstEntityAPI.Models;

namespace MyFirstEntityAPI.DATA
{
    public class MyEntityDbContext : DbContext
    {
        public MyEntityDbContext(DbContextOptions<MyEntityDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);
        }

    }
}
