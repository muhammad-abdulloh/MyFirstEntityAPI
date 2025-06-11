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

    }
}
