using Microsoft.EntityFrameworkCore;

namespace MVCDemoBook.Models
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }
        public DbSet<BookModel> books { get; set; }
    }
}
