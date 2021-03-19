using Microsoft.EntityFrameworkCore;
using model_dto_validation.Data.Entity;

namespace model_dto_validation.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
