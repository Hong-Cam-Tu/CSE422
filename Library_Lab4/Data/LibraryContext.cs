using Library_Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Lab4.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
