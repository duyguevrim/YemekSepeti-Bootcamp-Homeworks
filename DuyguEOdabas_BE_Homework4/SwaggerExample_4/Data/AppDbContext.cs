using Microsoft.EntityFrameworkCore;
using SwaggerExample_4.Data.Entity;

namespace SwaggerExample_4.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
